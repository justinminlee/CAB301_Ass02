// CAB301 - assignment 2
// An implementation of MovieCollection ADT
// 2023


using System;

//A class that models a node of a binary search tree
//An instance of this class is a node in the binary search tree 
public class BTreeNode
{
	private IMovie movie; // movie
	private BTreeNode? lchild; // reference to its left child 
	private BTreeNode? rchild; // reference to its right child

	public BTreeNode(IMovie movie)
	{
		this.movie = movie;
		lchild = null;
		rchild = null;
	}

	public IMovie Movie
	{
		get { return movie; }
		set { movie = value; }
	}

	public BTreeNode? LChild
	{
		get { return lchild; }
		set { lchild = value; }
	}

	public BTreeNode? RChild
	{
		get { return rchild; }
		set { rchild = value; }
	}
}

// invariant: no duplicate movie in this movie collection
public class MovieCollection : IMovieCollection
{
	private BTreeNode? root; // the root of the binary search tree in which movies are stored 
	private int count; // the number of movies currently stored in this movie collection 



	public int Number { get { return count; } }

	// constructor - create an empty movie collection
	public MovieCollection()
	{
		root = null;
		count = 0;	
	}

	public bool IsEmpty()
	{

		//To be completed by students
		if (count == 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	public bool Insert(IMovie movie)
	{

        //To be completed by students
        if (root == null)
        {
            root = new BTreeNode(movie);
            count++;
            return true;
        }

        BTreeNode curr = root;
        BTreeNode prev = null;
        while (curr != null)
        {
            if (movie.CompareTo(curr.Movie) == 0)
            {
                return false;
            }
            else if (movie.CompareTo(curr.Movie) < 0)
            {
                prev = curr;
                curr = curr.LChild;
            }
            else
            {
                prev = curr;
                curr = curr.RChild;
            }
        }

        if (movie.CompareTo(prev.Movie) < 0)
        {
            prev.LChild = new BTreeNode(movie);
        }
        else
        {
            prev.RChild = new BTreeNode(movie);
        }

        count++;
        return true;

    }


    public bool Delete(IMovie movie)
	{
        //To be completed by students

        // If empty, don't do anything
        if (root == null) 
        {
            return false;
        }

        // Try to find the movie in the tree
        BTreeNode? parent = null;
        BTreeNode? current = root;
        while (current != null)
        {
            int cmp = movie.CompareTo(current.Movie);
            if (cmp < 0)
            {
                parent = current;
                current = current.LChild;
            }
            else if (cmp > 0)
            {
                parent = current;
                current = current.RChild;
            }
            else
            {
                // Found the node that contains the movie to be deleted
                if (current.LChild == null && current.RChild == null)
                {
                    // Case 1: The node to be deleted is a leaf node
                    if (parent == null)
                    {
                        root = null;
                    }
                    else if (parent.LChild == current)
                    {
                        parent.LChild = null;
                    }
                    else
                    {
                        parent.RChild = null;
                    }
                }
                else if (current.LChild == null)
                {
                    // Case 2: The node to be deleted has one child (right child)
                    if (parent == null)
                    {
                        root = current.RChild;
                    }
                    else if (parent.LChild == current)
                    {
                        parent.LChild = current.RChild;
                    }
                    else
                    {
                        parent.RChild = current.RChild;
                    }
                }
                else if (current.RChild == null)
                {
                    // Case 2: The node to be deleted has one child (left child)
                    if (parent == null)
                    {
                        root = current.LChild;
                    }
                    else if (parent.LChild == current)
                    {
                        parent.LChild = current.LChild;
                    }
                    else
                    {
                        parent.RChild = current.LChild;
                    }
                }
                else
                {
                    // Case 3: The node to be deleted has two children
                    BTreeNode? minNode = current.RChild;
                    while (minNode.LChild != null)
                    {
                        minNode = minNode.LChild;
                    }
                    current.Movie = minNode.Movie;
                    current = minNode;
                    parent = null; // Reset parent to null to delete the minNode so reset parent to null
                }

                count--;
                return true;
            }
        }

        // If not found, don't do anything
        return false;

    }



	public IMovie? Search(string movietitle)
	{
        //To be completed by students

        // If empty, return null
        if (count == 0) return null;

        // Traverse the binary search tree to find the node with the matching movie title
        BTreeNode? current = root;
        while (current != null)
        {
            int cmp = String.Compare(movietitle, current.Movie.Title);
            if (cmp == 0) return current.Movie;
            else if (cmp < 0) current = current.LChild;
            else current = current.RChild;
        }

        // If not found, return null
        return null;

    }




    public int NoDVDs()
	{
        //To be completed by students
        int totalDVDs = 0;

        // Traverse the tree in-order and count the DVDs for each movie
        Stack<BTreeNode> stack = new Stack<BTreeNode>();
        BTreeNode current = root;
        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.LChild;
            }
            current = stack.Pop();
            totalDVDs += current.Movie.TotalCopies;
            current = current.RChild;
        }

        return totalDVDs;
    }


    public IMovie[] ToArray()
    {

        //To be completed by students
        IMovie[] movieArray = new IMovie[count];
        int index = 0;
        InOrderTraversal(root, ref movieArray, ref index);
        return movieArray;

    }

    private void InOrderTraversal(BTreeNode? node, ref IMovie[] movieArray, ref int index)
    {
        if (node != null)
        {
            InOrderTraversal(node.LChild, ref movieArray, ref index);
            movieArray[index] = node.Movie;
            index++;
            InOrderTraversal(node.RChild, ref movieArray, ref index);
        }
    }


    public void Clear()
	{

		//To be completed by students
		root = null;
		count = 0;

    }
}





