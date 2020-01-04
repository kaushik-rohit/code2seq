public static int getClosestFixedBits(int width)
    {
        if (width == 0) {
            return 1;
        }

        if (width >= 1 && width <= 24) {
            return width;
        }
        else if (width > 24 && width <= 26) {
            return 26;
        }
        else if (width > 26 && width <= 28) {
            return 28;
        }
        else if (width > 28 && width <= 30) {
            return 30;
        }
        else if (width > 30 && width <= 32) {
            return 32;
        }
        else if (width > 32 && width <= 40) {
            return 40;
        }
        else if (width > 40 && width <= 48) {
            return 48;
        }
        else if (width > 48 && width <= 56) {
            return 56;
        }
        else {
            return 64;
        }
    }