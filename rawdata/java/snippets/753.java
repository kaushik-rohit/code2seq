public int compareTo(Object o) {
        int thisValue = this.value;
        int thatValue = ((IntWritable) o).value;
        return (thisValue < thatValue ? -1 : (thisValue == thatValue ? 0 : 1));
    }