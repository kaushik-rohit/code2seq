private void UpdateBones(IReadOnlyDictionary<JointType, Joint> joints)
        {
            foreach (var bone in this.bones)
            {
                var joint0 = joints[bone.Item1];
                var joint1 = joints[bone.Item2];

                // If we can't find either of these joints, exit
                if (joint0.TrackingState == TrackingState.NotTracked ||
                    joint1.TrackingState == TrackingState.NotTracked)
                {
                    return;
                }

                var position0 = this.TranslatePosition(joint0.Position);
                var position1 = this.TranslatePosition(joint1.Position);
                this.DrawLines.Add(new Line(position0, position1, Color.White));
            }
        }