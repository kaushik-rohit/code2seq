private int calculateSoleTransitionPathLength(String str)
    {
        Stack<MDAGNode> transitionPathNodeStack = sourceNode.getTransitionPathNodes(str);
        transitionPathNodeStack.pop();  //The MDAGNode at the top of the stack is not needed
        //(we are processing the outgoing transitions of nodes inside str's _transition path,
        //the outgoing transitions of the MDAGNode at the top of the stack are outside this path)

        transitionPathNodeStack.trimToSize();

        //Process each node in transitionPathNodeStack, using each to determine whether the
        //_transition path corresponding to str is only used by str.  This is true if and only if
        //each node in the _transition path has a single outgoing _transition and is not an accept state.
        while (!transitionPathNodeStack.isEmpty())
        {
            MDAGNode currentNode = transitionPathNodeStack.peek();
            if (currentNode.getOutgoingTransitions().size() <= 1 && !currentNode.isAcceptNode())
                transitionPathNodeStack.pop();
            else
                break;
        }
        /////

        return (transitionPathNodeStack.capacity() - transitionPathNodeStack.size());
    }