protected override void Update(TimeSpan gameTime)
        {
            if (this.kinectService == null)
            {
                return;
            }

            var bodies = this.kinectService.Bodies;

            this.DrawPoints2DProjected.Clear();
            this.DrawLines.Clear();
            this.DrawOrientations.Clear();
            this.DrawPoints3D.Clear();

            var camera2D = this.RenderManager.ActiveCamera2D;

            if (bodies != null)
            {
                foreach (var body in bodies)
                {
                    if (body.IsTracked)
                    {
                        var joints = body.Joints;
                        var orientations = body.JointOrientations;

                        foreach (var jointType in joints.Keys)
                        {
                            var v = joints[jointType].Position;
                            var position = this.TranslatePosition(v);
                            this.DrawPoints2DProjected.Add(position);

                            Vector3 pos = Vector3.Zero;
                            pos.X = v.X;
                            pos.Y = v.Y;
                            pos.Z = v.Z;
                            this.DrawPoints3D.Add(pos);

                            var orientation = orientations[jointType].Orientation;
                            Quaternion q = new Quaternion()
                            {
                                X = orientation.X,
                                Y = orientation.Y,
                                Z = orientation.Z,

                                W = orientation.W
                            };

                            Vector3 axis;
                            float angle;

                            Quaternion.ToAngleAxis(ref q, out axis, out angle);

                            float aux = axis.X;
                            axis.X = axis.Y;
                            axis.Y = -aux;
                            axis.Z = axis.Z;

                            var m = Matrix.CreateFromAxisAngle(axis, angle);

                            var front = m.Forward;
                            var left = m.Left;
                            var up = m.Up;

                            float size = 0.1f;

                            front *= size;
                            left *= size;
                            up *= size;

                            this.DrawOrientations.Add(new Line(pos, pos + front, Color.Green));
                            this.DrawOrientations.Add(new Line(pos, pos + left, Color.Red));
                            this.DrawOrientations.Add(new Line(pos, pos + up, Color.Blue));
                        }

                        this.UpdateBones(joints);
                    }
                }
            }
        }