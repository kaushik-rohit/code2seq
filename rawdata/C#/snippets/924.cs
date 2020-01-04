void ISetLogicalParent.SetParent(ILogical parent)
        {
            var old = Parent;

            if (parent != old)
            {
                if (old != null && parent != null)
                {
                    throw new InvalidOperationException("The Control already has a parent.");
                }

                if (_isAttachedToLogicalTree)
                {
                    var oldRoot = FindStyleRoot(old) ?? this as IStyleRoot;

                    if (oldRoot == null)
                    {
                        throw new AvaloniaInternalException("Was attached to logical tree but cannot find root.");
                    }

                    var e = new LogicalTreeAttachmentEventArgs(oldRoot);
                    OnDetachedFromLogicalTreeCore(e);
                }

                if (InheritanceParent == null || parent == null)
                {
                    InheritanceParent = parent as AvaloniaObject;
                }

                Parent = (IStyledElement)parent;

                if (old != null)
                {
                    old.ResourcesChanged -= ThisResourcesChanged;
                }
                if (Parent != null)
                {
                    Parent.ResourcesChanged += ThisResourcesChanged;
                }
                ((ILogical)this).NotifyResourcesChanged(new ResourcesChangedEventArgs());

                if (Parent is IStyleRoot || Parent?.IsAttachedToLogicalTree == true || this is IStyleRoot)
                {
                    var newRoot = FindStyleRoot(this);

                    if (newRoot == null)
                    {
                        throw new AvaloniaInternalException("Parent is attached to logical tree but cannot find root.");
                    }

                    var e = new LogicalTreeAttachmentEventArgs(newRoot);
                    OnAttachedToLogicalTreeCore(e);
                }

                RaisePropertyChanged(ParentProperty, old, Parent, BindingPriority.LocalValue);
            }
        }