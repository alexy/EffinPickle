namespace EffinPickle.Core

open System
open Cirrious.CrossCore.IoC
open EffinPickle.Core.ViewModels

type App ()  = 
    inherit Cirrious.MvvmCross.ViewModels.MvxApplication()
    override u.Initialize() = 
        u.RegisterAppStart<FirstViewModel>()

    