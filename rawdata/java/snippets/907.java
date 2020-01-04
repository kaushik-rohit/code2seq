@Override
   public boolean add(T element)
   {
      if (size < elementData.length) {
         elementData[size++] = element;
      }
      else {
         // overflow-conscious code
         final int oldCapacity = elementData.length;
         final int newCapacity = oldCapacity << 1;
         @SuppressWarnings("unchecked")
         final T[] newElementData = (T[]) Array.newInstance(clazz, newCapacity);
         System.arraycopy(elementData, 0, newElementData, 0, oldCapacity);
         newElementData[size++] = element;
         elementData = newElementData;
      }

      return true;
   }