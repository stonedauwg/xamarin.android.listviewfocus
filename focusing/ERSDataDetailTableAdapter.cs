//
//  ERSDataDetailTableAdapter.cs
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Android.Support.V7.Widget;




namespace focusing
{
    public class RecyclerDataDetailAdapter : RecyclerView.Adapter, View.IOnFocusChangeListener
    {
        protected string[] Columns = { "itemnumber", "somethingelse1", "somethingelse2", "somethingelse3", "somethingelse4", "somethingelse5" };
        protected Dictionary<int, string> colNames = new Dictionary<int, string>();

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.DataDetailTableItem_TextBoxLayout, null);
            TextView columnNameLabel = view.FindViewById<TextView>(Resource.Id.ColumnNameLabel);
            columnNameLabel.SetTextColor(Color.Blue);
            columnNameLabel.Background = new ColorDrawable(Color.Transparent);
            columnNameLabel.Typeface = Typeface.Create("Verdana", TypefaceStyle.Normal);
            columnNameLabel.TextSize = 12.00F;
            EditText textField = view.FindViewById<EditText>(Resource.Id.TextField);
            textField.Enabled = true;// !column.ReadOnly && !this.Table.FullRowSelection;
            textField.Visibility = ViewStates.Visible;
            textField.SetTextColor(Color.Black);
            textField.Background = new ColorDrawable(Color.Transparent);
            textField.Typeface = Typeface.Create("Verdana", TypefaceStyle.Normal);
            textField.TextSize = 16.00F;
            textField.OnFocusChangeListener = this;
            return new RecyclerDataDetailViewHolder(view);
            
        }

        // Fill in the contents of the photo card (invoked by the layout manager):
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            string column = this.Columns[position];
            RecyclerDataDetailViewHolder vh = holder as RecyclerDataDetailViewHolder;
            TextView textField = vh.label;
            textField.Tag = position;
            textField.Text = column;
            this.colNames[position] = column;
        }

        // Return the number of photos available in the photo album:
        public override int ItemCount
        {
            get { return this.Columns.Length; }
        }

        public class RecyclerDataDetailViewHolder : RecyclerView.ViewHolder
        {
            
            public TextView label;

            public RecyclerDataDetailViewHolder(View view) : base(view)
            {
                label = view.FindViewById<TextView>(Resource.Id.ColumnNameLabel);
            }
        }

        public void OnFocusChange(View v, bool hasFocus)
        {
            Console.WriteLine($"adapter focuschange:{this.colNames[Convert.ToInt32(v.Tag)]} {v} hasfocus={hasFocus}");
        }
    }



    public class ERSDataDetailTableAdapter : BaseAdapter<string>, View.IOnFocusChangeListener
	{
		protected Context Context { get; set; }
		
		protected int SelectedRow { get; set; }
        protected int SelectedColumn { get; set; }
        //protected string[] Columns = { "itemnumber", "somethingelse1", "somethingelse2", "somethingelse3", "somethingelse4", "somethingelse5" };
        protected string[] Columns = { "itemnumber", "somethingelse1" };
        protected Dictionary<int, string> colNames = new Dictionary<int, string>();

        public ERSDataDetailTableAdapter(Context context)
		{
			this.Context = context;
			
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override string this[int position]
		{
			// NOTE: not used
			get { return null; }
			//get { return Elements[position]; }
		}

		public override int Count
		{
			get { return this.Columns.Length; }
		}

        

        public override View GetView(int position, View convertView, ViewGroup parent)
		{

			View view = convertView; // re-use an existing view, if one is available

            string column = this.Columns[position];
           

            // NOTE: Because of the controls and their handlers, disable view re-use
            //if (view == null) // otherwise create a new one
            {
                LayoutInflater layoutInflater = LayoutInflater.FromContext(this.Context);
                view = layoutInflater.Inflate(Resource.Layout.DataDetailTableItem_TextBoxLayout, null);
                
            }

            

			RelativeLayout layout = view.FindViewById<RelativeLayout>(Resource.Id.MainPageLayout);
			

			TextView columnNameLabel = view.FindViewById<TextView>(Resource.Id.ColumnNameLabel);
			if (columnNameLabel != null)
			{
				columnNameLabel.SetTextColor(Color.Blue);

				columnNameLabel.Background = new ColorDrawable(Color.Transparent);

				columnNameLabel.Typeface = Typeface.Create("Verdana", TypefaceStyle.Normal);
				columnNameLabel.TextSize = 12.00F;

				columnNameLabel.Text = column;
			}

			EditText textField = view.FindViewById<EditText>(Resource.Id.TextField);
			if (textField != null)
			{
                // TODO: fix text mask
                textField.Tag = position;
                this.colNames[position] = column;

                //textField.Initialize(false, row[column.Name], ' ', ERSMaskFillDirection.Left, control);

                textField.Enabled = true;// !column.ReadOnly && !this.Table.FullRowSelection;
                textField.Visibility = ViewStates.Visible;
                textField.SetTextColor(Color.Black);
                textField.Background = new ColorDrawable(Color.Transparent);
                textField.Typeface = Typeface.Create("Verdana", TypefaceStyle.Normal);
                textField.TextSize = 16.00F;

                //textField.ViewAttachedToWindow += (sender, args) =>
                //{
                    textField.OnFocusChangeListener = this;
                //};
                //textField.ViewDetachedFromWindow += (sender, args) =>
                //{
                //    textField.OnFocusChangeListener = null;
                //};
                
            }
            view.OnFocusChangeListener = this;
			return view;
		}

        public void OnFocusChange(View v, bool hasFocus)
        {
            Console.WriteLine($"adapter focuschange:{this.colNames[Convert.ToInt32(v.Tag)]} {v} hasfocus={hasFocus}");
        }
    }
}
