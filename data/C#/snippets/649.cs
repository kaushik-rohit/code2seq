public void Initialize(int minPoolSize, int maxPoolSize, ISmartPoolSourceCreator<T> sourceCreator)
        {
            m_MinPoolSize = minPoolSize;
            m_MaxPoolSize = maxPoolSize;
            m_SourceCreator = sourceCreator;
            m_GlobalStack = new ConcurrentStack<T>();

            var n = 0;

            if (minPoolSize != maxPoolSize)
            {
                var currentValue = minPoolSize;

                while (true)
                {
                    n++;

                    var thisValue = currentValue * 2;

                    if (thisValue >= maxPoolSize)
                        break;

                    currentValue = thisValue;
                }
            }

            m_ItemsSource = new ISmartPoolSource[n + 1];

            T[] items;
            m_ItemsSource[0] = sourceCreator.Create(minPoolSize, out items);
            m_CurrentSourceCount = 1;

            for (var i = 0; i < items.Length; i++)
            {
                m_GlobalStack.Push(items[i]);
            }

            m_TotalItemsCount = m_MinPoolSize;
        }