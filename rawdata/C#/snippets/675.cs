[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public virtual void DisposeEventBridge()
        {
			if( null != _hTMLObjectElementEvents_SinkHelper)
			{
				_hTMLObjectElementEvents_SinkHelper.Dispose();
				_hTMLObjectElementEvents_SinkHelper = null;
			}

			_connectPoint = null;
		}