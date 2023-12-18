using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class MySpace
{
    private readonly LinkedList<AbstractSpace> _space;

    public MySpace(LinkedList<AbstractSpace> space)
    {
        _space = new LinkedList<AbstractSpace>(space);
    }

    public MySpace(params AbstractSpace[] space)
    {
        _space = new LinkedList<AbstractSpace>(space);
    }

    public bool HasNext()
    {
        return _space.Count > 0;
    }

    public AbstractSpace GetNext()
    {
        AbstractSpace next = _space.First();
        _space.RemoveFirst();
        return next;
    }

    public MySpace Clone()
    {
        return new MySpace(_space);
    }
}