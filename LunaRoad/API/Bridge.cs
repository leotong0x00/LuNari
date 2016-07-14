﻿/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016  Denis Kuzmin <entry.reg@gmail.com>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using System;
using net.r_eg.LunaRoad.API.Lua51;
using net.r_eg.LunaRoad.API.Lua52;
using net.r_eg.LunaRoad.API.Lua53;

namespace net.r_eg.LunaRoad.API
{
    internal sealed class Bridge<TAPI>: Func53, IAPI<TAPI>, ILuaCommon, ILua51, ILua52, ILua53 
        where TAPI: ILevel
    {
        private IProvider provider;

        public TAPI Lua
        {
            get {
                return (TAPI)(ILevel)this;
            }
        }

        /// <summary>
        /// Binds the exported function.
        /// </summary>
        /// <typeparam name="T">Type of delegate.</typeparam>
        /// <param name="lpProcName">The name of exported function.</param>
        /// <returns>Delegate of exported function.</returns>
        public override T bindFunc<T>(string lpProcName)
        {
            return provider.bindFunc<T>(lpProcName);
        }

        /// <summary>
        /// Binds the exported C API Function.
        /// </summary>
        /// <typeparam name="T">Type of delegate.</typeparam>
        /// <param name="func">The name of exported C API function.</param>
        /// <returns>Delegate of exported function.</returns>
        public override T bind<T>(string func)
        {
            return provider.bind<T>(func);
        }

        public Bridge(IProvider provider)
        {
            if(provider == null) {
                throw new ArgumentException("Provider cannot be null.");
            }
            this.provider = provider;
        }
    }
}