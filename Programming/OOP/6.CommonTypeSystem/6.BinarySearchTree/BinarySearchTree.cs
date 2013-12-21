partial class BinarySearchTree<T>
{
    private TreeNode root = null;


    //public TreeNode Root
    //{
    //    get { return this.root; }
    //    set { this.root = value; }
    //}

    public int Count { get; private set; }

    public void Add(T key)
    {
        if (root == null)
        {
            root = new TreeNode(key);
        }
        else
        {
            TreeNode current = this.root;
            while (true)
            {
                int compared = current.Key.CompareTo(key);
                if (compared == 0) return;
                else if (compared < 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode(key);
                        break;
                    }
                    current = current.Right;
                }
                else if (compared > 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode(key);
                        break;
                    }
                    current = current.Left;
                }
            }
        }
        this.Count++;
    }

    public bool Contains(T key)
    {
        TreeNode current = this.root;
        while (current != null)
        {
            int compared = current.Key.CompareTo(key);
            if (compared == 0) return true;
            else if (compared < 0) current = root.Left;
            else if (compared > 0) current = root.Right;
        }
        return false;
    }
}
