namespace TrafficControl.DAL.RestSharp.Types
{
    public abstract class LongIDBaseType:GenericBase<long>
    { 
        public long Id { get; set; }
    }
    public abstract class StringIDBaseType : GenericBase<string>
    {
        public string Id { get; set; }

    }
public abstract class Base
{
    public abstract void Use();
    public abstract object GetId();
}

public abstract class GenericBase<T> : Base
{
    public abstract T IDz { get; set; }
    public T Id { get; set; }

    public override object GetId()
    {
        return Id;
    }
}
}