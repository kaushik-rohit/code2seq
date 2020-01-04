@MainThread
  public void resumeAnimation() {
    if (compositionLayer == null) {
      lazyCompositionTasks.add(new LazyCompositionTask() {
        @Override
        public void run(LottieComposition composition) {
          resumeAnimation();
        }
      });
      return;
    }
    animator.resumeAnimation();
  }