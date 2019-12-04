protected void Start()
        {
            if (isStartedCapturePhase) return;
            var root = parent;

            // Search root object
            if (root == null)
            {
                root = this;
            }
            else
            {
                while (root.Parent != null)
                {
                    root = root.Parent;
                }
            }

            root.StartCapturePhase();
        }