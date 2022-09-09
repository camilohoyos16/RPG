using System.Collections;
using System.Collections.Generic;

public interface IItem
{
    public ItemData ItemData { get; set; }
    public void UseItem();
}