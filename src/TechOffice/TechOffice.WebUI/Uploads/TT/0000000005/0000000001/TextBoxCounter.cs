/*
 * CHANGES:
 * ========
 * 2009-01-06: Integrated changes made by David Dude to include support for maximum character and word properties and to display
 *             different styles when the word or character boundary is exceeded. Also updated the JavaScript to include the placeholders
 *             {2}, {3}, {4}, and {5}, which show the number of words remaining, the number of characters remaining, the maximum
 *             number of characters allowed, and the maximum number of words allowed, respectively. 
 * 
 *             NOTE: These max length properties do NOT prohibit the user from entering more characters than specified. 
 *             You'll need to use validators or server-side logic to ensure that the user's input is within appropriate bounds.
 * 
 */

using System.ComponentModel;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace skmControls2
{
    public class TextBoxCounter : WebControl
    {
        #region Properties
        [Description("The ID of the TextBox control to count."), DefaultValue(""), Themeable(false), Category("Behavior")]
        public virtual string TextBoxControlId
        {
            get
            {
                object o = this.ViewState["TextBoxControlId"];
                
                if (o != null)
                    return (string) o;
                else
                    return string.Empty;
            }
            set
            {
                this.ViewState["TextBoxControlId"] = value;
            }
        }

        [Description("The format to display the current count. Use {0} for the word count, {1} for the character count, {2} for the number of words remaining, {3} for the number of characters remaining, {4} for the maximum number of words allowed, {5} for the maximum number of characters allowed."), DefaultValue("{0} words, {1} characters"), Themeable(true), Category("Appearance")]
        public virtual string DataFormatString
        {
            get
            {
                object o = this.ViewState["DataFormatString"];

                if (o != null)
                    return (string)o;
                else
                    return "{0} words, {1} characters";
            }
            set
            {
                this.ViewState["DataFormatString"] = value;
            }
        }

        [Description("Should carriage returns count as two characters?"), DefaultValue(false), Themeable(true), Category("Behavior")]
        public virtual bool TreatCarriageReturnsAsOneCharacter
        {
            get
            {
                object o = this.ViewState["TreatCarriageReturnsAsOneCharacter"];

                if (o != null)
                    return (bool)o;
                else
                    return false;
            }
            set
            {
                this.ViewState["TreatCarriageReturnsAsOneCharacter"] = value;
            }
        }

        [Category("Behavior"), DefaultValue(0), Description("The maximum number of characters allowed."), Themeable(false)]
        public virtual int MaxCharacterLength
        {
            get
            {
                object o = this.ViewState["MaxCharacterLength"];

                if (o != null)
                    return (int)o;
                else
                    return 0;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");

                this.ViewState["MaxCharacterLength"] = value;
            }
        }

        [Category("Behavior"), DefaultValue(0), Description("The maximum number of words allowed."), Themeable(false)]
        public virtual int MaxWordLength
        {
            get
            {
                object o = this.ViewState["MaxWordLength"];

                if (o != null)
                    return (int)o;
                else
                    return 0;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");

                this.ViewState["MaxWordLength"] = value;
            }
        }

        [Description("The the integer percentage at which to apply the warning CSS class."), DefaultValue(0), Themeable(false), Category("Behavior")]
        public virtual int WarningPercentage
        {
            get
            {
                object o = this.ViewState["WarningPercentage"];

                if (o != null)
                    return (int)o;
                else
                    return 0;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Value must be between 0 and 100.");

                this.ViewState["WarningPercentage"] = value;
            }
        }

        [Description("The CSS class to use when word or character counts are at or exceed the count maximums."), DefaultValue(""), Themeable(true), Category("Appearance")]
        public virtual string CssClassForMax
        {
            get
            {
                object o = this.ViewState["CssClassForMax"];

                if (o != null)
                    return (string)o;
                else
                    return string.Empty;
            }
            set
            {
                this.ViewState["CssClassForMax"] = value;
            }
        }

        [Description("The CSS class to use when when or characters counts are greater than the specified WarningPercentage."), DefaultValue(""), Themeable(true), Category("Appearance")]
        public virtual string CssClassForWarning
        {
            get
            {
                object o = this.ViewState["CssClassForWarning"];

                if (o != null)
                    return (string)o;
                else
                    return string.Empty;
            }
            set
            {
                this.ViewState["CssClassForWarning"] = value;
            }
        }


        /// <summary>
        /// Returns the total number of characters in the associated TextBox.
        /// </summary>
        [Browsable(false)]
        public virtual int Characters
        {
            get
            {
                TextBox tb = GetTextBoxControl();
                string content = tb.Text;

                if (TreatCarriageReturnsAsOneCharacter)
                    content = content.Replace("\r\n", "\n");

                return content.Length;
            }
        }

        /// <summary>
        /// Returns the total number of words in the associated TextBox.
        /// </summary>
        [Browsable(false)]
        public virtual int Words
        {
            get
            {
                TextBox tb = GetTextBoxControl();
                string uniformSpaces = Regex.Replace(tb.Text, "\\s", " ", RegexOptions.Compiled | RegexOptions.Multiline);
                string[] pieces = uniformSpaces.Split(" ".ToCharArray());

                int wordCount = 0;
                for (int i = 0; i < pieces.Length; i++)
                    if (pieces[i].Length > 0)
                        wordCount++;

                return wordCount;
            }
        }
        #endregion

        #region Methods
        protected override void RenderContents(HtmlTextWriter writer)
        {
            // Specify the output to display in Design mode
            if (base.DesignMode)
                writer.Write(string.Concat("[", this.ID, "]"));

            base.RenderContents(writer);
        }

        public override void Focus()
        {
            throw new NotSupportedException("The Focus() method is not supported for controls of this type.");
        }

        protected virtual TextBox GetTextBoxControl()
        {
            if (string.IsNullOrEmpty(this.TextBoxControlId))
                throw new HttpException(string.Format("You must provide a value for the TextBoxControlId property for the TextBoxCounter control with ID '{0}'.", this.ID));

            TextBox tb = this.FindControl(this.TextBoxControlId) as TextBox;
            if (tb == null)
                throw new HttpException(string.Format("The TextBoxCounter control with ID '{0}' could not find a TextBox control with the ID '{1}'.", this.ID, this.TextBoxControlId));

            return tb;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);


            string treatCRasOneChar = "false";
            if (this.TreatCarriageReturnsAsOneCharacter)
                treatCRasOneChar = "true";



            /* We need to add three bits of JavaScript to the page:
             *  (1) The include file that has the JavaScript function to count the characters/words
             *  (2) JavaScript that will call the appropriate function in (1) when a key is pressed in the TextBoxControlId TextBox
             *  (3) JavaScript to set the display for this control when the page is first loaded.
             */

            // (1) Register the skmControls2 client-side functions using WebResource.axd (if needed)
            // see: http://aspnet.4guysfromrolla.com/articles/080906-1.aspx
            if (this.Page != null && !this.Page.ClientScript.IsClientScriptIncludeRegistered("skmControls2"))
                this.Page.ClientScript.RegisterClientScriptInclude("skmControls2", this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "skmControls2.skmControls2.js"));


            // (2) Call skm_CountTextBox onkeyup
            TextBox tb = GetTextBoxControl();
            tb.Attributes["onkeyup"] += string.Format("skm_CountTextBox('{0}', '{1}', '{2}', {3}, {4}, {5}, '{6}', '{7}', '{8}', {9});", 
                    tb.ClientID, this.ClientID, this.DataFormatString.Replace("'", "\\'"), treatCRasOneChar,
                    this.MaxCharacterLength, this.MaxWordLength, this.CssClass, this.CssClassForWarning,
                    this.CssClassForMax, this.WarningPercentage);


            // (3) Call skm_CountTextBox on page load
            Page.ClientScript.RegisterStartupScript(this.GetType(), System.Guid.NewGuid().ToString(), string.Format("skm_CountTextBox('{0}', '{1}', '{2}', {3}, {4}, {5}, '{6}', '{7}', '{8}', {9});",
                    tb.ClientID, this.ClientID, this.DataFormatString.Replace("'", "\\'"), treatCRasOneChar, this.MaxCharacterLength, this.MaxWordLength,
                    this.CssClass, this.CssClassForWarning, this.CssClassForMax, this.WarningPercentage), 
                    true);
        }
        #endregion
    }
}
