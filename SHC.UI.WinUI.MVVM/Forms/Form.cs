using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SHC.UI.WinUI.MVVM.Forms;

public partial class Form : ObservableObject
{
    public IDictionary<string, IFormField> Fields { get; set; }
    public Form(Dictionary<string, IFormField> fields)
    {
        Fields = fields;
    }
    public bool IsValid()
    {
        bool isValid = true;
        foreach (var field in Fields.Values)
        {
            if (!field.IsValid())
            {
                isValid = false;
            }
        }
        return isValid;
    }

    public T CastTo<T>(T result) where T : new()
    {
        foreach (var kvp in Fields)
        {
            var prop = typeof(T).GetProperty(kvp.Key, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(result, kvp.Value.Value);
            }
        }
        return result;
    }
}
