package md5ca7f5c2e1ab208a9cd1a4d7fe5d86908;


public class RecyclerDataDetailAdapter_RecyclerDataDetailViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("focusing.RecyclerDataDetailAdapter+RecyclerDataDetailViewHolder, focusing", RecyclerDataDetailAdapter_RecyclerDataDetailViewHolder.class, __md_methods);
	}


	public RecyclerDataDetailAdapter_RecyclerDataDetailViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == RecyclerDataDetailAdapter_RecyclerDataDetailViewHolder.class)
			mono.android.TypeManager.Activate ("focusing.RecyclerDataDetailAdapter+RecyclerDataDetailViewHolder, focusing", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
