private Vector2 TranslatePosition(CameraSpacePoint point)
        {
            Vector2 position = Vector2.Zero;
            switch (this.currentSource)
            {
                case KinectSources.Color:
                    var colorPoint = this.kinectService.Mapper.MapCameraPointToColorSpace(point);
                    position = new Vector2(colorPoint.X * this.colorFactorX, colorPoint.Y * this.colorFactorY);

                    break;
                case KinectSources.Depth:
                    var depthPoint = this.kinectService.Mapper.MapCameraPointToDepthSpace(point);
                    position = new Vector2(depthPoint.X * this.depthFactorX, depthPoint.Y * this.depthFactorY);
                    break;
                default:
                    break;
            }

            return position;
        }