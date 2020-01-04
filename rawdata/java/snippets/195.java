public static List<Commit> matchCommitToPulls(List<Commit> commits, List<GitRequest> pullRequests) {
        List<Commit> newCommitList = new LinkedList<>();
        if (CollectionUtils.isEmpty(commits) || CollectionUtils.isEmpty(pullRequests)) {
            return commits;
        }
        //TODO: Need to optimize this method
        for (Commit commit : commits) {
            Iterator<GitRequest> pIter = pullRequests.iterator();
            boolean foundPull = false;
            while (!foundPull && pIter.hasNext()) {
                GitRequest pull = pIter.next();
                if (Objects.equals(pull.getScmRevisionNumber(), commit.getScmRevisionNumber()) ||
                        Objects.equals(pull.getScmMergeEventRevisionNumber(), commit.getScmRevisionNumber())) {
                    foundPull = true;
                    commit.setPullNumber(pull.getNumber());
                } else {
                    List<Commit> prCommits = pull.getCommits();
                    boolean foundCommit = false;
                    if (!CollectionUtils.isEmpty(prCommits)) {
                        Iterator<Commit> cIter = prCommits.iterator();
                        while (!foundCommit && cIter.hasNext()) {
                            Commit loopCommit = cIter.next();
                            if (Objects.equals(commit.getScmAuthor(), loopCommit.getScmAuthor()) &&
                                    (commit.getScmCommitTimestamp() == loopCommit.getScmCommitTimestamp()) &&
                                    Objects.equals(commit.getScmCommitLog(), loopCommit.getScmCommitLog())) {
                                foundCommit = true;
                                foundPull = true;
                                commit.setPullNumber(pull.getNumber());
                            }
                        }
                    }
                }
            }
            newCommitList.add(commit);
        }
        return newCommitList;
    }