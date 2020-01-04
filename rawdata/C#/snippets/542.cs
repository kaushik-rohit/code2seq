protected override void ResolveDependencies()
        {
            base.ResolveDependencies();

            this.kinectService = WaveServices.GetService<KinectService>();

            this.DrawPoints2DProjected = new List<Vector2>();
            this.DrawPoints3D = new List<Vector3>();
            this.DrawLines = new List<Line>();
            this.DrawOrientations = new List<Line>();
        }