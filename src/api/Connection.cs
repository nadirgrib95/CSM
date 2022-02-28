﻿using System.Collections.Generic;
using System.Reflection;
using ICities;

namespace CSM.API
{
    public abstract class Connection
    {
        /// <summary>
        ///     The name of this mod support instance.
        ///     Used for checking compatibility to other players
        ///     as well as showing error messages.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        ///     If this instance should be enabled, only then
        ///     the register/unregister methods are called and
        ///     the command handlers are registered.
        /// </summary>
        public bool Enabled { get; protected set; }

        /// <summary>
        ///     A list of assemblies to search for command handlers.
        ///     If this instance is enabled, all found commands
        ///     are added to the protocol.
        /// </summary>
        public List<Assembly> CommandAssemblies { get; } = new List<Assembly>();

        /// <summary>
        ///     Register all handlers for changes to send to other players.
        ///     This method can for example be used to setup Harmony patches.
        ///     If will be called in the LevelLoaded handler of the LoadingExtension.
        /// </summary>
        /// <param name="mode">The load mode of the game (See Cities LoadingExtension).</param>
        public abstract void RegisterHandlers(LoadMode mode);

        /// <summary>
        ///     Unregister all previously registered handlers.
        ///     This method can for example be used to remove Harmony patches.
        ///     If will be called in the LevelUnloading handler of the LoadingExtension.
        /// </summary>
        public abstract void UnregisterHandlers();
    }
}
