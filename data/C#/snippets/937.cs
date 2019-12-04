public override double Predict(Vector y)
        {
            var tempy = this.PolynomialFeatures > 0 ? PreProcessing.FeatureDimensions.IncreaseDimensions(y, this.PolynomialFeatures) : y;
            tempy = tempy.Insert(0, 1.0);
            return this.LogisticFunction.Compute((tempy * this.Theta).ToDouble()) >= 0.5 ? 1d : 0d;
        }