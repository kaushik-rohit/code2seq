@Scheduled(fixedRateString = "${hystrix.stream.queue.sendRate:${hystrix.stream.queue.send-rate:500}}")
	public void sendMetrics() {
		ArrayList<String> metrics = new ArrayList<>();
		this.jsonMetrics.drainTo(metrics);

		if (!metrics.isEmpty()) {
			if (log.isTraceEnabled()) {
				log.trace("sending stream metrics size: " + metrics.size());
			}
			for (String json : metrics) {
				// TODO: batch all metrics to one message
				try {
					// TODO: remove the explicit content type when s-c-stream can handle
					// that for us
					this.outboundChannel.send(MessageBuilder.withPayload(json)
							.setHeader(MessageHeaders.CONTENT_TYPE,
									this.properties.getContentType())
							.build());
				}
				catch (Exception ex) {
					if (log.isTraceEnabled()) {
						log.trace("failed sending stream metrics: " + ex.getMessage());
					}
				}
			}
		}
	}