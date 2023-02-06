using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Business.PageObjects.OnlinerMobileApp
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Hierarchy));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Hierarchy)serializer.Deserialize(reader);
    // }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AndroidSupportV4WidgetDrawerLayout
    {
        [JsonProperty("android.widget.FrameLayout")]
        public List<AndroidWidgetFrameLayout> AndroidWidgetFrameLayout { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class AndroidSupportV7WidgetLinearLayoutCompat
    {
        [JsonProperty("android.widget.TextView")]
        public AndroidWidgetTextView AndroidWidgetTextView { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class AndroidSupportV7WidgetRecyclerView
    {
        [JsonProperty("android.widget.FrameLayout")]
        public List<AndroidWidgetFrameLayout> AndroidWidgetFrameLayout { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class AndroidViewView
    {
        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class AndroidViewViewGroup
    {
        [JsonProperty("android.widget.ImageButton")]
        public AndroidWidgetImageButton AndroidWidgetImageButton { get; set; }

        [JsonProperty("android.widget.ImageView")]
        public AndroidWidgetImageView AndroidWidgetImageView { get; set; }

        [JsonProperty("android.support.v7.widget.LinearLayoutCompat")]
        public AndroidSupportV7WidgetLinearLayoutCompat AndroidSupportV7WidgetLinearLayoutCompat { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class AndroidWidgetFrameLayout
    {
        [JsonProperty("android.widget.LinearLayout")]
        public AndroidWidgetLinearLayout AndroidWidgetLinearLayout { get; set; }

        [JsonProperty("android.view.View")]
        public AndroidViewView AndroidViewView { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }

        [JsonProperty("android.support.v4.widget.DrawerLayout")]
        public AndroidSupportV4WidgetDrawerLayout AndroidSupportV4WidgetDrawerLayout { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }
    }

    public class AndroidWidgetImageButton
    {
        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_content-desc")]
        public string ContentDesc { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class AndroidWidgetImageView
    {
        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }
    }

    public class AndroidWidgetLinearLayout
    {
        [JsonProperty("android.widget.FrameLayout")]
        public List<AndroidWidgetFrameLayout> AndroidWidgetFrameLayout { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }

        [JsonProperty("android.view.ViewGroup")]
        public AndroidViewViewGroup AndroidViewViewGroup { get; set; }

        [JsonProperty("android.widget.ViewAnimator")]
        public AndroidWidgetViewAnimator AndroidWidgetViewAnimator { get; set; }

        [JsonProperty("android.widget.ImageView")]
        public AndroidWidgetImageView AndroidWidgetImageView { get; set; }

        [JsonProperty("android.widget.TextView")]
        public AndroidWidgetTextView AndroidWidgetTextView { get; set; }
    }

    public class AndroidWidgetTextView
    {
        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_content-desc")]
        public string ContentDesc { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class AndroidWidgetViewAnimator
    {
        [JsonProperty("android.support.v7.widget.RecyclerView")]
        public AndroidSupportV7WidgetRecyclerView AndroidSupportV7WidgetRecyclerView { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_package")]
        public string Package { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_text")]
        public string Text { get; set; }

        [JsonProperty("_resource-id")]
        public string ResourceId { get; set; }

        [JsonProperty("_checkable")]
        public string Checkable { get; set; }

        [JsonProperty("_checked")]
        public string Checked { get; set; }

        [JsonProperty("_clickable")]
        public string Clickable { get; set; }

        [JsonProperty("_enabled")]
        public string Enabled { get; set; }

        [JsonProperty("_focusable")]
        public string Focusable { get; set; }

        [JsonProperty("_focused")]
        public string Focused { get; set; }

        [JsonProperty("_long-clickable")]
        public string LongClickable { get; set; }

        [JsonProperty("_password")]
        public string Password { get; set; }

        [JsonProperty("_scrollable")]
        public string Scrollable { get; set; }

        [JsonProperty("_selected")]
        public string Selected { get; set; }

        [JsonProperty("_bounds")]
        public string Bounds { get; set; }

        [JsonProperty("_displayed")]
        public string Displayed { get; set; }
    }

    public class Hierarchy
    {
        [JsonProperty("android.widget.FrameLayout")]
        public List<AndroidWidgetFrameLayout> AndroidWidgetFrameLayout { get; set; }

        [JsonProperty("_index")]
        public string Index { get; set; }

        [JsonProperty("_class")]
        public string Class { get; set; }

        [JsonProperty("_rotation")]
        public string Rotation { get; set; }

        [JsonProperty("_width")]
        public string Width { get; set; }

        [JsonProperty("_height")]
        public string Height { get; set; }
    }

    public class Root
    {
        [JsonProperty("hierarchy")]
        public Hierarchy Hierarchy { get; set; }
    }




}
