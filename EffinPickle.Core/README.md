F# (Effin) PCL (Pickle) Exploration in Xamarin Studio on Mac
------------------------------------------------------------

I'd like to follow the N+1 days of MvvmCross tutorials in F#, e.g. translating the original C# into F#.  
I've been doing a lot of OCaml but .NET and Mono are generally new to me, I've tried them many times on Mac OSX
and they finally work very well under Xamarin Studio, with the great use case of cross-platform mobile development.

MvvmCross starts with a Core library as a C# PCL project, however, until 2/20/2014, there was no F# PCL.  
In the current masters there is one, here's how to get it:

- select Alpha channel in Xamarin Studio and update, get Mono 3.2.7
- install F# bindings, their version will be 3.2.23
- install F# iOS add-in

Get github.com/fsharp/fsharp, do

    ./autogen.sh --prefix=/Library/Frameworks/Mono.framework/Versions/3.2.7
    make
    make install

Then get <https://github.com/fsharp/fsharpbinding>, install from monodevelop/ per fsharp.org/use/ios/.
Installing the package will warn about uninstalling the 3.2.23 version, and will now show 3.2.24.  
The F# iOS addin will be disabled, you can reenable it.

Now we create a new solution `EffinPickle` with an _F# Portable Library project_, `EffinPickle.Core`.

We set the portable profile 78 per various tweets.  `:)`

In Xamarin Studio, we add addin repository <http://mrward.github.com/monodevelop-nuget-addin-repository/4.0/main.mrep>, 
and install NuGet addin.  With it, we install package MvvmCross, MvvmCross CrossCore.

Juan Gómez created an F# translation of the MvvmCross Hello World example 
<http://jmgomez.me/reaching-the-nirvana-mvvmcross-xamarin.ios-fsharp>.
The project looks like it was developed in Visual Studio and the `ReachingNirvana.Core` library is not portable.  It was not building in Xamarin Studio on Mac.

We copy the `App.fs` form it, and split out the view model into the new `FirstViewModel.fs` file into `ViewModels` folder.  
We remove the `.cs` equivalents from the MvvmCross template.

Building shows the following error in `FirstViewModel.fs`:

    /Users/Alexy/Projects/EffinPickle/EffinPickle.Core/ViewModels/FirstViewModel.fs(6,6): Error FS1108: The type 'INotifyPropertyChanged' is required here and is unavailable. You must add a reference to assembly 'System, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e, Retargetable=Yes'. (FS1108) (EffinPickle.Core)

Obviosly the C# equivalent, produced by adding the same MvvmCross NuGet packages, does not require that dependency.

What is going on?
