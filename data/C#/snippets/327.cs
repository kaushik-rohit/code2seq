private void seekToPosition(Vector2 screenPosition)
        {
            if (Beatmap.Value == null)
                return;

            float markerPos = MathHelper.Clamp(ToLocalSpace(screenPosition).X, 0, DrawWidth);
            seekTo(markerPos / DrawWidth * Beatmap.Value.Track.Length);
        }