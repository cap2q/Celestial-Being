#pragma checksum "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0e931af5959a2fead9c798ecd0bd39cf205eec8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CompileResults), @"mvc.1.0.view", @"/Views/Home/CompileResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/CompileResults.cshtml", typeof(AspNetCore.Views_Home_CompileResults))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\_ViewImports.cshtml"
using CelestialBeing;

#line default
#line hidden
#line 2 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\_ViewImports.cshtml"
using CelestialBeing.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0e931af5959a2fead9c798ecd0bd39cf205eec8", @"/Views/Home/CompileResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1d50d3e938b1d1bd76161d40e81f6940137021a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CompileResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CelestialBeing.Models.AsteroidModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
  
    ViewBag.Title = "Celestial Being";

#line default
#line hidden
            BeginContext(99, 337, true);
            WriteLiteral(@"
<div><b>Asteroids Approximate to Earth </b><br /></div>
<table class=""table table-bordered table-responsive table-hover"">
    <tr>
        <th>Asteroid Name</th>
        <th>Asteroid ID</th>
        <th>Minimum Diameter (Miles)</th>
        <th>Maximum Diameter (Miles)</th>
        <th>Potentially Hazardous</th>

    </tr>
");
            EndContext();
#line 17 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
     foreach (var asteroid in Model)
    {

#line default
#line hidden
            BeginContext(481, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(512, 13, false);
#line 20 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
           Write(asteroid.Name);

#line default
#line hidden
            EndContext();
            BeginContext(525, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(549, 11, false);
#line 21 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
           Write(asteroid.Id);

#line default
#line hidden
            EndContext();
            BeginContext(560, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(584, 33, false);
#line 22 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
           Write(asteroid.EstimatedMinimumDiameter);

#line default
#line hidden
            EndContext();
            BeginContext(617, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(641, 33, false);
#line 23 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
           Write(asteroid.EstimatedMaximumDiameter);

#line default
#line hidden
            EndContext();
            BeginContext(674, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(698, 29, false);
#line 24 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
           Write(asteroid.PotentiallyHazardous);

#line default
#line hidden
            EndContext();
            BeginContext(727, 21, true);
            WriteLiteral("</td>\r\n       </tr>\r\n");
            EndContext();
#line 26 "C:\Users\Selrach\source\repos\CelestialBeing\CelestialBeing\Views\Home\CompileResults.cshtml"
    } 

#line default
#line hidden
            BeginContext(756, 12, true);
            WriteLiteral("</table>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CelestialBeing.Models.AsteroidModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591