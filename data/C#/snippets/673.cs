[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public virtual void CreateEventBridge()
        {
			if(false == Factory.Settings.EnableEvents)
				return;
	
			if (null != _connectPoint)
				return;
	
            if (null == _activeSinkId)
				_activeSinkId = SinkHelper.GetConnectionPoint(this, ref _connectPoint, NetOffice.MSHTMLApi.Behind.EventContracts.HTMLObjectElementEvents_SinkHelper.Id);


			if(NetOffice.MSHTMLApi.Behind.EventContracts.HTMLObjectElementEvents_SinkHelper.Id.Equals(_activeSinkId, StringComparison.InvariantCultureIgnoreCase))
			{
				_hTMLObjectElementEvents_SinkHelper = new NetOffice.MSHTMLApi.Behind.EventContracts.HTMLObjectElementEvents_SinkHelper(this, _connectPoint);
				return;
			} 
        }