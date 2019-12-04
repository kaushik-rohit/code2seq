public static void AVgeomFilter(String [] argv)
  {
  //Prefix Content is: ""
  
  // create pipeline - structured grid[]
  //[]
  pl3d = new vtkMultiBlockPLOT3DReader();
  pl3d.SetXYZFileName((string)"" + (VTK_DATA_ROOT.ToString()) + "/Data/combxyz.bin");
  pl3d.SetQFileName((string)"" + (VTK_DATA_ROOT.ToString()) + "/Data/combq.bin");
  pl3d.SetScalarFunctionNumber((int)100);
  pl3d.SetVectorFunctionNumber((int)202);
  pl3d.Update();
  gf = new vtkGeometryFilter();
  gf.SetInputData((vtkDataSet)pl3d.GetOutput().GetBlock(0));
  gMapper = vtkPolyDataMapper.New();
  gMapper.SetInputConnection((vtkAlgorithmOutput)gf.GetOutputPort());
  gMapper.SetScalarRange((double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[0],
      (double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[1]);
  gActor = new vtkActor();
  gActor.SetMapper((vtkMapper)gMapper);
  gf2 = new vtkGeometryFilter();
  gf2.SetInputData((vtkDataSet)pl3d.GetOutput().GetBlock(0));
  gf2.ExtentClippingOn();
  gf2.SetExtent((double)10,(double)17,(double)-6,(double)6,(double)23,(double)37);
  gf2.PointClippingOn();
  gf2.SetPointMinimum((int)0);
  gf2.SetPointMaximum((int)10000);
  gf2.CellClippingOn();
  gf2.SetCellMinimum((int)0);
  gf2.SetCellMaximum((int)7500);
  g2Mapper = vtkPolyDataMapper.New();
  g2Mapper.SetInputConnection((vtkAlgorithmOutput)gf2.GetOutputPort());
  g2Mapper.SetScalarRange((double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[0],
      (double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[1]);
  g2Actor = new vtkActor();
  g2Actor.SetMapper((vtkMapper)g2Mapper);
  g2Actor.AddPosition((double)0,(double)15,(double)0);
  // create pipeline - poly data[]
  //[]
  gf3 = new vtkGeometryFilter();
  gf3.SetInputConnection((vtkAlgorithmOutput)gf.GetOutputPort());
  g3Mapper = vtkPolyDataMapper.New();
  g3Mapper.SetInputConnection((vtkAlgorithmOutput)gf3.GetOutputPort());
  g3Mapper.SetScalarRange((double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[0],
      (double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[1]);
  g3Actor = new vtkActor();
  g3Actor.SetMapper((vtkMapper)g3Mapper);
  g3Actor.AddPosition((double)0,(double)0,(double)15);
  gf4 = new vtkGeometryFilter();
  gf4.SetInputConnection((vtkAlgorithmOutput)gf2.GetOutputPort());
  gf4.ExtentClippingOn();
  gf4.SetExtent((double)10,(double)17,(double)-6,(double)6,(double)23,(double)37);
  gf4.PointClippingOn();
  gf4.SetPointMinimum((int)0);
  gf4.SetPointMaximum((int)10000);
  gf4.CellClippingOn();
  gf4.SetCellMinimum((int)0);
  gf4.SetCellMaximum((int)7500);
  g4Mapper = vtkPolyDataMapper.New();
  g4Mapper.SetInputConnection((vtkAlgorithmOutput)gf4.GetOutputPort());
  g4Mapper.SetScalarRange((double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[0],
      (double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[1]);
  g4Actor = new vtkActor();
  g4Actor.SetMapper((vtkMapper)g4Mapper);
  g4Actor.AddPosition((double)0,(double)15,(double)15);
  // create pipeline - unstructured grid[]
  //[]
  s = new vtkSphere();
  s.SetCenter(((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetCenter()[0], 
              ((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetCenter()[1], 
              ((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetCenter()[2]);
  s.SetRadius((double)100.0);
  //everything[]
  eg = new vtkExtractGeometry();
  eg.SetInputData((vtkDataSet)pl3d.GetOutput().GetBlock(0));
  eg.SetImplicitFunction((vtkImplicitFunction)s);
  gf5 = new vtkGeometryFilter();
  gf5.SetInputConnection((vtkAlgorithmOutput)eg.GetOutputPort());
  g5Mapper = vtkPolyDataMapper.New();
  g5Mapper.SetInputConnection((vtkAlgorithmOutput)gf5.GetOutputPort());
  g5Mapper.SetScalarRange((double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[0],
      (double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[1]);
  g5Actor = new vtkActor();
  g5Actor.SetMapper((vtkMapper)g5Mapper);
  g5Actor.AddPosition((double)0,(double)0,(double)30);
  gf6 = new vtkGeometryFilter();
  gf6.SetInputConnection((vtkAlgorithmOutput)eg.GetOutputPort());
  gf6.ExtentClippingOn();
  gf6.SetExtent((double)10,(double)17,(double)-6,(double)6,(double)23,(double)37);
  gf6.PointClippingOn();
  gf6.SetPointMinimum((int)0);
  gf6.SetPointMaximum((int)10000);
  gf6.CellClippingOn();
  gf6.SetCellMinimum((int)0);
  gf6.SetCellMaximum((int)7500);
  g6Mapper = vtkPolyDataMapper.New();
  g6Mapper.SetInputConnection((vtkAlgorithmOutput)gf6.GetOutputPort());
  g6Mapper.SetScalarRange((double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[0],
      (double)((vtkDataSet)pl3d.GetOutput().GetBlock(0)).GetScalarRange()[1]);
  g6Actor = new vtkActor();
  g6Actor.SetMapper((vtkMapper)g6Mapper);
  g6Actor.AddPosition((double)0,(double)15,(double)30);
  // create pipeline - rectilinear grid[]
  //[]
  rgridReader = new vtkRectilinearGridReader();
  rgridReader.SetFileName((string)"" + (VTK_DATA_ROOT.ToString()) + "/Data/RectGrid2.vtk");
  rgridReader.Update();
  gf7 = new vtkGeometryFilter();
  gf7.SetInputConnection((vtkAlgorithmOutput)rgridReader.GetOutputPort());
  g7Mapper = vtkPolyDataMapper.New();
  g7Mapper.SetInputConnection((vtkAlgorithmOutput)gf7.GetOutputPort());
  g7Mapper.SetScalarRange((double)((vtkDataSet)rgridReader.GetOutput()).GetScalarRange()[0],(double)((vtkDataSet)rgridReader.GetOutput()).GetScalarRange()[1]);
  g7Actor = new vtkActor();
  g7Actor.SetMapper((vtkMapper)g7Mapper);
  g7Actor.SetScale((double)3,(double)3,(double)3);
  gf8 = new vtkGeometryFilter();
  gf8.SetInputConnection((vtkAlgorithmOutput)rgridReader.GetOutputPort());
  gf8.ExtentClippingOn();
  gf8.SetExtent((double)0,(double)1,(double)-2,(double)2,(double)0,(double)4);
  gf8.PointClippingOn();
  gf8.SetPointMinimum((int)0);
  gf8.SetPointMaximum((int)10000);
  gf8.CellClippingOn();
  gf8.SetCellMinimum((int)0);
  gf8.SetCellMaximum((int)7500);
  g8Mapper = vtkPolyDataMapper.New();
  g8Mapper.SetInputConnection((vtkAlgorithmOutput)gf8.GetOutputPort());
  g8Mapper.SetScalarRange((double)((vtkDataSet)rgridReader.GetOutput()).GetScalarRange()[0],(double)((vtkDataSet)rgridReader.GetOutput()).GetScalarRange()[1]);
  g8Actor = new vtkActor();
  g8Actor.SetMapper((vtkMapper)g8Mapper);
  g8Actor.SetScale((double)3,(double)3,(double)3);
  g8Actor.AddPosition((double)0,(double)15,(double)0);
  // Create the RenderWindow, Renderer and both Actors[]
  //[]
  ren1 = vtkRenderer.New();
  renWin = vtkRenderWindow.New();
  renWin.AddRenderer((vtkRenderer)ren1);
  iren = new vtkRenderWindowInteractor();
  iren.SetRenderWindow((vtkRenderWindow)renWin);
  ren1.AddActor((vtkProp)gActor);
  ren1.AddActor((vtkProp)g2Actor);
  ren1.AddActor((vtkProp)g3Actor);
  ren1.AddActor((vtkProp)g4Actor);
  ren1.AddActor((vtkProp)g5Actor);
  ren1.AddActor((vtkProp)g6Actor);
  ren1.AddActor((vtkProp)g7Actor);
  ren1.AddActor((vtkProp)g8Actor);
  renWin.SetSize((int)340,(int)550);
  cam1 = ren1.GetActiveCamera();
  cam1.SetClippingRange((double)84,(double)174);
  cam1.SetFocalPoint((double)5.22824,(double)6.09412,(double)35.9813);
  cam1.SetPosition((double)100.052,(double)62.875,(double)102.818);
  cam1.SetViewUp((double)-0.307455,(double)-0.464269,(double)0.830617);
  iren.Initialize();
  // prevent the tk window from showing up then start the event loop[]
  
//deleteAllVTKObjects();
  }