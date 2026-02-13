public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (no duplicates allowed)
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
            return true;
        
        if (value < Data)
        {
            // Search in left subtree
            if (Left == null)
                return false;
            return Left.Contains(value);
        }
        else
        {
            // Search in right subtree
            if (Right == null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = 0;
        int rightHeight = 0;
        
        if (Left != null)
            leftHeight = Left.GetHeight();
        
        if (Right != null)
            rightHeight = Right.GetHeight();
        
        // Height includes this node + the max height from either subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}