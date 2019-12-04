public Emgu.CV.ExtrinsicCameraParameters Calibrate(System.Drawing.PointF[] image_points) {
      return Emgu.CV.CameraCalibration.FindExtrinsicCameraParams2(
       _converted_object_points,
       image_points,
       _intrinsics);
    }