public T ProcessActionResult(string responseJson, Enum theAction)
        {
            var cs = new ControlStream { CommandResponse = responseJson };

            return cs.ItemCast(default(T));
        }