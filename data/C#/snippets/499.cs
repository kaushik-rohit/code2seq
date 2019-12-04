protected override void OnReceive(object message)
        {
            var terminated = message as Terminated;
            if (terminated != null)
            {
                var t = terminated;
                Cell.RemoveRoutee(new ActorRefRoutee(t.ActorRef), false);
                StopIfAllRouteesRemoved();
            }
            else if (message is AdjustPoolSize)
            {
                var poolSize = message as AdjustPoolSize;
                if (poolSize.Change > 0)
                {
                    var newRoutees = Enumerable.Repeat(Pool.NewRoutee(Cell.RouteeProps, Context), poolSize.Change).ToArray();
                    Cell.AddRoutees(newRoutees);
                }
                else if (poolSize.Change < 0)
                {
                    var currentRoutees = Cell.Router.Routees.ToArray();

                    var abandon = currentRoutees
                        .Drop(currentRoutees.Length + poolSize.Change)
                        .ToList();

                    Cell.RemoveRoutees(abandon, true);
                }
            }
            else
            {
                base.OnReceive(message);
            }
        }