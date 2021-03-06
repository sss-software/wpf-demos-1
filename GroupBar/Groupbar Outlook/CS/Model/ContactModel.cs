#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupbarOutlookDemo
{
    public class ContactModel  : IComparable<ContactModel>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public int CompareTo(ContactModel other)
        {
            return string.Compare(this.Name, other.Name);
        }
    }
}
