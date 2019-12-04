protected override void PrepareProcess (Process process) {
            base.PrepareProcess(process);
            SetEnvironment(process);
        }