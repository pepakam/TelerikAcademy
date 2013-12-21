partial class BinarySearchTree<T>
{
    internal class TreeNode
    {
        public T Key { get; private set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(T key)
        {
            this.Key = key;
        }
    }
}