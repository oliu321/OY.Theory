using OY.Theory.DataStructures.Stack;
using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OY.Theory.Graph.Basic
{
    public class StronglyConnectedComponentsAlgorithmVertex : DepthFirstSearchVertex
    {
        public int ComponentId { get; set; }
    }

    public class StartingNewComponentEventArgs : EventArgs
    {
        public int NewComponentId { get; protected set; }
        public StartingNewComponentEventArgs(int newComponentId)
        {
            this.NewComponentId = newComponentId;
        }
    }

    public class AddedVertexToComponentEventArgs : EventArgs
    {
        public int ComponentId { get; protected set; }
        public StronglyConnectedComponentsAlgorithmVertex Vertex { get; protected set; }
        public AddedVertexToComponentEventArgs(int componentId, StronglyConnectedComponentsAlgorithmVertex vertex)
        {
            this.ComponentId = componentId;
            this.Vertex = vertex;
        }
    }
    public class StronglyConnectedComponentsAlgorithm
    {
        public EventHandler<StartingNewComponentEventArgs> StartingNewComponent;
        public EventHandler<AddedVertexToComponentEventArgs> AddedVertexToComponent;

        protected void OnStartingNewComponent(StartingNewComponentEventArgs e)
        {
            e.Raise(this, ref this.StartingNewComponent);
        }
        protected void OnAddedVertexToComponent(AddedVertexToComponentEventArgs e)
        {
            e.Raise(this, ref this.AddedVertexToComponent);
        }

        public void Run(StronglyConnectedComponentsAlgorithmVertex[] graph)
        {
            var stack = new ResizingArrayStack<StronglyConnectedComponentsAlgorithmVertex>();
            var dfs1 = new DepthFirstSearchAlgorithm();
            dfs1.DoReverse = true;
            dfs1.VertexMarkedAsBlack += (s, e) => { stack.Push((StronglyConnectedComponentsAlgorithmVertex) e.Vertex); };
            dfs1.Run(graph);
            for (int i = 0; i < graph.Length; ++i)
            {
                graph[i] = stack.Pop();
                graph[i].Color = DepthFirstSearchVertexColor.WHITE;
            }

            var dfs2 = new DepthFirstSearchAlgorithm();
            int componentId = 0;
            dfs2.StartingNewComponent += 
                (s, e) => {
                    OnStartingNewComponent(new StartingNewComponentEventArgs(++componentId));
                };
            dfs2.VertexMarkedAsBlack += (s, e) => {
                OnAddedVertexToComponent(new AddedVertexToComponentEventArgs(componentId, (StronglyConnectedComponentsAlgorithmVertex)e.Vertex));
                ((StronglyConnectedComponentsAlgorithmVertex)e.Vertex).ComponentId = componentId; 
            };
            dfs2.Run(graph);
        }
    }
}
