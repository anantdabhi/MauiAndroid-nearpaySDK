
using Java.Interop;
namespace IO.Nearpay.Sdk.Receipt.Reconcile
{
    public sealed partial class ReconcileSchemeAdapter : global::AndroidX.RecyclerView.Widget.RecyclerView.Adapter
    {
        public override unsafe void OnBindViewHolder(global::AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder holder, int position)
        {
            const string __id = "onBindViewHolder.(Lio/nearpay/sdk/receipt/reconcile/ReconcileSchemeAdapter$ReconciliationViewHolder;I)V";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[2];
                __args[0] = new JniArgumentValue((holder == null) ? IntPtr.Zero : ((global::Java.Lang.Object)holder).Handle);
                __args[1] = new JniArgumentValue(position);
                _members.InstanceMethods.InvokeAbstractVoidMethod(__id, this, __args);
            }
            finally
            {
                global::System.GC.KeepAlive(holder);
            }
        }
    }
}
