﻿namespace SqualrCore.Source.Editors.StreamIconEditor
{
    using SqualrCore.Source.Api.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for a class which listens for changes in the loading of the stream icons.
    /// </summary>
    internal interface IStreamIconsLoadedObserver
    {
        /// <summary>
        /// Recieves a notification of the loaded stream icons.
        /// </summary>
        /// <param name="streamIcons">The loaded stream icons.</param>
        void Update(IEnumerable<StreamIcon> streamIcons);
    }
    //// End interface
}
//// End namespace