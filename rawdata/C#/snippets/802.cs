protected void RecursiveNestedJoin(EventBean lookupEvent, int nestingOrderIndex, EventBean[] currentPath, ICollection<EventBean[]> result, ExprEvaluatorContext exprEvaluatorContext)
        {
            var nestedResult = new List<EventBean[]>();
            var nestedExecNode = _childNodes[nestingOrderIndex];
            nestedExecNode.Process(lookupEvent, currentPath, nestedResult, exprEvaluatorContext);
            var isLastStream = nestingOrderIndex == _nestingOrderLength - 1;
    
            // This is not the last nesting level so no result rows are added. Invoke next nesting level for
            // each event found.
            if (!isLastStream) {
                for (int ii = 0; ii < nestedResult.Count; ii++)
                {
                    var row = nestedResult[ii];
                    EventBean lookup = row[_nestedStreams[nestingOrderIndex]];
                    RecursiveNestedJoin(lookup, nestingOrderIndex + 1, row, result, exprEvaluatorContext);
                }
                return;
            }
    
            // Loop to add result rows
            for(int ii = 0; ii < nestedResult.Count; ii++) {
                result.Add(nestedResult[ii]);
            }
        }