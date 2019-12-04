public bool SetLine(IPresentationImage sliceImage, IPresentationImage referenceImage)
			{
				DicomImagePlane sliceImagePlane = DicomImagePlane.FromImage(sliceImage);
				DicomImagePlane referenceImagePlane = DicomImagePlane.FromImage(referenceImage);

				if (!sliceImagePlane.IsParallelTo(referenceImagePlane, 1f))
				{
					Vector3D imagePt1 = referenceImagePlane.ConvertToImagePlane(sliceImagePlane.PositionPatientTopLeft);
					Vector3D imagePt2 = referenceImagePlane.ConvertToImagePlane(sliceImagePlane.PositionPatientTopRight);

					this.Points.SuspendEvents();
					this.Points.Clear();
					this.Points.Add(referenceImagePlane.ConvertToImage(new PointF(imagePt1.X, imagePt1.Y)));
					this.Points.Add(referenceImagePlane.ConvertToImage(new PointF(imagePt2.X, imagePt2.Y)));
					this.Points.ResumeEvents();
					return true;
				}
				return false;
			}