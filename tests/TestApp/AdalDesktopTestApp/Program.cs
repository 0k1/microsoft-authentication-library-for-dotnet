﻿//----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;

using TestApp.PCL;

namespace AdalDesktopTestApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                AcquireTokenAsync().Wait();
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae.InnerException.Message);
                Console.WriteLine(ae.InnerException.StackTrace);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static async Task AcquireTokenAsync()
        {
            TokenBroker tokenBroker = new TokenBroker();
             string token = await tokenBroker.GetTokenWithUsernamePasswordAsync();
            Console.WriteLine(token + "\n");
            token = await tokenBroker.GetTokenWithClientCredentialAsync();
            Console.WriteLine(token);
        }
    }
}
