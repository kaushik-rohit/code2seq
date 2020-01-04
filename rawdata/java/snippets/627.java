public void setStrictlyCoLocatedWith(JobVertex strictlyCoLocatedWith) {
		if (this.slotSharingGroup == null || this.slotSharingGroup != strictlyCoLocatedWith.slotSharingGroup) {
			throw new IllegalArgumentException("Strict co-location requires that both vertices are in the same slot sharing group.");
		}

		CoLocationGroup thisGroup = this.coLocationGroup;
		CoLocationGroup otherGroup = strictlyCoLocatedWith.coLocationGroup;

		if (otherGroup == null) {
			if (thisGroup == null) {
				CoLocationGroup group = new CoLocationGroup(this, strictlyCoLocatedWith);
				this.coLocationGroup = group;
				strictlyCoLocatedWith.coLocationGroup = group;
			}
			else {
				thisGroup.addVertex(strictlyCoLocatedWith);
				strictlyCoLocatedWith.coLocationGroup = thisGroup;
			}
		}
		else {
			if (thisGroup == null) {
				otherGroup.addVertex(this);
				this.coLocationGroup = otherGroup;
			}
			else {
				// both had yet distinct groups, we need to merge them
				thisGroup.mergeInto(otherGroup);
			}
		}
	}