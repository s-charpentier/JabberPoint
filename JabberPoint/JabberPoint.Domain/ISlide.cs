using System;
using System.Collections.Generic;
using System.Text;
using JabberPoint.Domain.Content;

namespace JabberPoint.Domain
{
    public interface IPageComponent
    {

        List<IContent> Contents { get; }
    }
    public interface ISlide: IPageComponent{}
    public interface IFooter: IPageComponent {}
}
