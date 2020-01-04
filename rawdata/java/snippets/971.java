private void processOrphanCommits(GitHubRepo repo) {
        long refTime = Math.min(System.currentTimeMillis() - gitHubSettings.getCommitPullSyncTime(), gitHubClient.getRepoOffsetTime(repo));
        List<Commit> orphanCommits = commitRepository.findCommitsByCollectorItemIdAndTimestampAfterAndPullNumberIsNull(repo.getId(), refTime);
        List<GitRequest> pulls = gitRequestRepository.findByCollectorItemIdAndMergedAtIsBetween(repo.getId(), refTime, System.currentTimeMillis());
        orphanCommits = CommitPullMatcher.matchCommitToPulls(orphanCommits, pulls);
        List<Commit> orphanSaveList = orphanCommits.stream().filter(c -> !StringUtils.isEmpty(c.getPullNumber())).collect(Collectors.toList());
        orphanSaveList.forEach( c -> LOG.info( "Updating orphan " + c.getScmRevisionNumber() + " " +
                new DateTime(c.getScmCommitTimestamp()).toString("yyyy-MM-dd hh:mm:ss.SSa") + " with pull " + c.getPullNumber()));
        commitRepository.save(orphanSaveList);
    }