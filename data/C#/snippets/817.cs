private static void DumpObject(Object o, String name, IDictionary<Object, String> visitedObjects, Boolean dumpObjectsOnlyOnce)
        {
            // Handle names that look like passwords first in order to give no information
            // at all - not even that the object is null.
            if (ObjectDumper.HandleNameLooksLikePassword(name)) return;

            if (ObjectDumper.HandleObjectIsNull(name, o)) return;

            if (ObjectDumper.HandleObjectTreeBackAndCrossReferences(name, o, visitedObjects, dumpObjectsOnlyOnce)) return;

            // Handle possible infinite recursion after all other aborting cases
            // because they will abort the expansion in a more meaningful way.
            // This constraint prevents from entering a infinite recursion in whole
            // class of nasty cases. For example if a object exposes a dynamically
            // constructed new instances of its type through one if its properties.
            // An example is the struct DateTime that has a property Date exposing
            // another DateTime instance. (This is just an example - DateTime is
            // actually handled in a different way.)
            if (ObjectDumper.HandlePossibleInfiniteRecursion(name)) return;

            // Add the object to the visited objects to allow detection of object tree
            // cross and back references.
            ObjectDumper.AddObjectToVisitedObjectsIfRequired(name, o, visitedObjects);

            ObjectDumper.HandleWellFormedCases(name, o, visitedObjects, dumpObjectsOnlyOnce);

            // If requested, remove object from visited objects to allow dumping it again.
            ObjectDumper.RemoveObjectFromVisitedObjectsIfRequested(o, visitedObjects, dumpObjectsOnlyOnce);
        }