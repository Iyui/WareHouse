using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareHouse.Statement.Manager
{
    class VBRemark
    {
        /*If Trim(cobCode.Text) <> "" And txtInnumber.Text <> "" And cobProvider.Text <> "" Then
        If IsNumeric(txtInnumber.Text) And Val(txtInnumber) > 0 Then
           oldnumber = Val(Trim(adoIn.Recordset.Fields("数量")))
           If oldnumber < 0 Then
              MsgBox ("此记录为已修改记录的赤字记录！不能修改！")
              Screen.MousePointer = vbDefault
              Exit Sub
           End If
           If adoIn.Recordset.Fields("缴库单价") <> "" Then
              oldprice = Val(adoIn.Recordset.Fields("缴库单价"))
           Else
              oldprice = 0
           End If
           If txtInprice.Text <> "" Then
              If IsNumeric(txtInprice.Text) Then
                 nowprice = Val(txtInprice.Text)
              Else
                 Screen.MousePointer = vbDefault
                 MsgBox ("价格不能输入非数字符号！")
                 'Screen.MousePointer = vbDefault
                 Exit Sub
              End If
            Else
                nowprice = 0
            End If
            nownumber = Val(txtInnumber.Text)
            'oldcode = Trim(adoIn.Recordset.Fields("物资编号"))
            strs = Trim(adoIn.Recordset.Fields("入库序号"))
            riqi = Format(Trim(adoIn.Recordset.Fields("缴库日期")))
          
           'cnnn.Open "Provider=MSDASQL.1;Persist Security Info=False;Data Source=storemanage;Initial Catalog=storemanage"
           cnnn.Open "Provider=MSDASQL.1;Password=quit9,garden;Persist Security Info=True;User ID=sa;Data Source=storemanage"
           'order by 缴库日期
           inrs.Open "select * from in_goods where 入库序号='" + strs + "' ", cnnn, adOpenKeyset, adLockOptimistic
           'warers.Open "select * from storehouse where 物资编号='" + oldcode + "'", cnnn, adOpenKeyset, adLockOptimistic
           warers.Open "select * from storehouse where 物资编号='" + Trim(cobCode.Text) + "'", cnnn, adOpenKeyset, adLockOptimistic
           outrs.Open "select 数量,库存单价,金额,结存数量,结存金额 from out_goods where 物资编号='" + Trim(cobCode.Text) + "' And 领料日期  > '" + riqi + "' order by 领料日期", cnnn, adOpenKeyset, adLockOptimistic
           outrrss.Open "select sum(数量) As 总数 from out_goods where 物资编号='" + Trim(cobCode.Text) + "' And 领料日期  > '" + riqi + "'", cnnn, adOpenKeyset, adLockOptimistic
           If Not (inrs.BOF And inrs.EOF) Then
              
              '一定要存在，否则就出错
              If Not (warers.BOF And warers.EOF) Then
                 Dim outnumber As Double
                 If outrrss.Fields("总数") <> "" Then
                    outnumber = Val(outrrss.Fields("总数"))
                 Else
                    outnumber = 0
                 End If
                 cnnn.BeginTrans
                 If oldprice <> nowprice Or oldnumber <> nownumber Then
                    storenumber = Val(warers.Fields("数量"))
                    If oldnumber <> nownumber Then
                       If (oldnumber - nownumber) > storenumber Then
                          cnnn.RollbackTrans
                          inrs.Close
                          outrs.Close
                          warers.Close
                          outrrss.Close
                          cnnn.Close
                          Screen.MousePointer = vbDefault
                          MsgBox ("对不起！您输入的数量太小！不够已做的出库操作！")
                          Exit Sub
                       End If
                    End If
                    
                    inrs.AddNew
                    inrs.Fields("物资编号") = adoIn.Recordset.Fields("物资编号")
                    If adoIn.Recordset.Fields("品名") <> "" Then inrs.Fields("品名") = Trim(adoIn.Recordset.Fields("品名"))
                    If adoIn.Recordset.Fields("规格") <> "" Then inrs.Fields("规格") = Trim(adoIn.Recordset.Fields("规格"))
                    If adoIn.Recordset.Fields("计量单位") <> "" Then inrs.Fields("计量单位") = Trim(adoIn.Recordset.Fields("计量单位"))
         
                    If adoIn.Recordset.Fields("缴库单价") <> "" Then inrs.Fields("缴库单价") = Val(adoIn.Recordset.Fields("缴库单价"))
                    inrs.Fields("数量") = Val(adoIn.Recordset.Fields("数量")) * (-1)
                    If adoIn.Recordset.Fields("金额") <> "" Then inrs.Fields("金额") = Val(adoIn.Recordset.Fields("金额")) * (-1)
         
                    If adoIn.Recordset.Fields("供货单位") <> "" Then inrs.Fields("供货单位") = Trim(adoIn.Recordset.Fields("供货单位"))
                    If adoIn.Recordset.Fields("制造厂家") <> "" Then inrs.Fields("制造厂家") = Trim(adoIn.Recordset.Fields("制造厂家"))
         
                    If adoIn.Recordset.Fields("缴库日期") <> "" Then inrs.Fields("缴库日期") = Format(adoIn.Recordset.Fields("缴库日期"))
                    inrs.Fields("缴库人") = Trim(cobProvider.Text)
                    If adoIn.Recordset.Fields("缴库部门") <> "" Then inrs.Fields("缴库部门") = Trim(adoIn.Recordset.Fields("缴库部门"))
                    If adoIn.Recordset.Fields("入库单编号") <> "" Then inrs.Fields("入库单编号") = Trim(adoIn.Recordset.Fields("入库单编号"))
                    If adoIn.Recordset.Fields("发票编号") <> "" Then inrs.Fields("发票编号") = Trim(adoIn.Recordset.Fields("发票编号"))
                    If adoIn.Recordset.Fields("备注") <> "" Then inrs.Fields("备注") = Trim(adoIn.Recordset.Fields("备注"))
                    If adoIn.Recordset.Fields("结存数量") <> "" Then inrs.Fields("结存数量") = Val(adoIn.Recordset.Fields("结存数量")) * (-1)
                    If adoIn.Recordset.Fields("结存金额") <> "" Then inrs.Fields("结存金额") = Val(adoIn.Recordset.Fields("结存金额")) * (-1)
                    
                    
                    inrs.AddNew
                    inrs.Fields("物资编号") = Trim(cobCode.Text)
                    If cobName.Text <> "" Then inrs.Fields("品名") = Trim(cobName.Text)
                    If cobSpecification.Text <> "" Then inrs.Fields("规格") = Trim(cobSpecification.Text)
                    If cobUnits.Text <> "" Then inrs.Fields("计量单位") = Trim(cobUnits.Text)
         
                    If txtInprice.Text <> "" Then inrs.Fields("缴库单价") = Val(txtInprice.Text)
                    inrs.Fields("数量") = Val(txtInnumber.Text)
                    If txtMoney.Text <> "" Then inrs.Fields("金额") = Val(txtMoney.Text)
         
                    If txtCompany.Text <> "" Then inrs.Fields("供货单位") = Trim(txtCompany.Text)
                    If txtMaked.Text <> "" Then inrs.Fields("制造厂家") = Trim(txtMaked.Text)
         
                    If dtpDate.Value <> "" Then inrs.Fields("缴库日期") = Format(Trim(dtpDate.Value), "General Date")
                    inrs.Fields("缴库人") = Trim(cobProvider.Text)
                    If cobDepartment.Text <> "" Then inrs.Fields("缴库部门") = Trim(cobDepartment.Text)
                    If txtBillcode.Text <> "" Then inrs.Fields("入库单编号") = Trim(txtBillcode.Text)
                    If txtInvoice.Text <> "" Then inrs.Fields("发票编号") = Trim(txtInvoice.Text)
                    If txtRemark.Text <> "" Then inrs.Fields("备注") = Trim(txtRemark.Text)
                    
                    If adoIn.Recordset.Fields("结存数量") <> "" Then
                       If Val(adoIn.Recordset.Fields("结存数量")) > 0 Then
                          If oldprice > 0 And nowprice > 0 Then
                             If Val(adoIn.Recordset.Fields("结存数量")) - oldnumber + nownumber <> 0 Then
                                price = Format((Val(adoIn.Recordset.Fields("结存金额")) - oldnumber * oldprice + nownumber * nowprice) / (Val(adoIn.Recordset.Fields("结存数量")) - oldnumber + nownumber), "#0.000000")
                             Else
                                cnnn.RollbackTrans
                                inrs.Close
                                outrs.Close
                                warers.Close
                                outrrss.Close
                                cnnn.Close
                                Screen.MousePointer = vbDefault
                                MsgBox ("数量不符！不能修改！")
                                Exit Sub
                             End If
                          Else
                             If nowprice > 0 Then
                                price = nowprice
                             Else
                               If warers.Fields("库存单价") <> "" Then price = Val(warers.Fields("库存单价")) Else price = 0 'oldprice  ' 有可能出错
                             End If
                          End If
                          inrs.Fields("结存数量") = Val(adoIn.Recordset.Fields("结存数量")) - oldnumber + nownumber
                          inrs.Fields("结存金额") = Format(inrs.Fields("结存数量") * price, "#0.000000")
                       Else
                          myanswer = MsgBox("该记录为原始记录！修改它可能造成错误或混乱！您确定要修改它吗？", vbYesNo)
                          If myanswer = vbYes Then
                             If warers.Fields("库存单价") <> "" Then
                                If Val(warers.Fields("库存单价")) > 0 Then
                                   If nowprice > 0 And oldprice > 0 Then
                                      If warers.Fields("数量") + outnumber + nownumber - oldnumber <> 0 Then
                                         price = Format(((warers.Fields("数量") + outnumber) * Val(warers.Fields("库存单价")) + nowprice * nownumber - oldprice * oldnumber) / (warers.Fields("数量") + outnumber + nownumber - oldnumber), "#0.000000")
                                      Else
                                         cnnn.RollbackTrans
                                         inrs.Close
                                         outrs.Close
                                         warers.Close
                                         outrrss.Close
                                         cnnn.Close
                                         Screen.MousePointer = vbDefault
                                         MsgBox ("数量不符！不能修改！")
                                         Exit Sub
                                      End If
                                   Else
                                      If nowprice > 0 Then
                                         price = Format(((warers.Fields("数量") + outnumber - oldnumber) * Val(warers.Fields("库存单价")) + nowprice * nownumber) / (warers.Fields("数量") + outnumber + nownumber - oldnumber), "#0.000000")
                                      Else
                                         price = Val(warers.Fields("库存单价"))
                                      End If
                                   End If
                                Else
                                   price = nowprice
                                   
                                End If
                             Else
                                price = nowprice
                             End If
                             inrs.Fields("结存数量") = inrs.Fields("结存数量") - oldnumber + nownumber
                             inrs.Fields("结存金额") = Format(inrs.Fields("结存数量") * price, "#0.000000")
                          Else
                             cnnn.RollbackTrans
                             inrs.Close
                             outrs.Close
                             warers.Close
                             outrrss.Close
                             cnnn.Close
                             Screen.MousePointer = vbDefault
                             Exit Sub
                          End If
                       End If
                    Else
                       myanswer = MsgBox("该记录为原始记录！修改它可能造成错误或混乱！您确定要修改它吗？", vbYesNo)
                       If myanswer = vbYes Then
                          If warers.Fields("库存单价") <> "" Then
                             If Val(warers.Fields("库存单价")) > 0 Then
                                 If nowprice > 0 And oldprice > 0 Then
                                    If warers.Fields("数量") + outnumber + nownumber - oldnumber <> 0 Then
                                       price = Format(((warers.Fields("数量") + outnumber) * Val(warers.Fields("库存单价")) + nowprice * nownumber - oldprice * oldnumber) / (warers.Fields("数量") + outnumber + nownumber - oldnumber), "#0.000000")
                                    Else
                                       cnnn.RollbackTrans
                                       inrs.Close
                                       outrs.Close
                                       warers.Close
                                       outrrss.Close
                                       cnnn.Close
                                       Screen.MousePointer = vbDefault
                                       MsgBox ("数量不符！不能修改！")
                                       Exit Sub
                                    End If
                                 Else
                                    If nowprice > 0 Then
                                       price = Format(((warers.Fields("数量") + outnumber - oldnumber) * Val(warers.Fields("库存单价")) + nowprice * nownumber) / (warers.Fields("数量") + outnumber + nownumber - oldnumber), "#0.000000")
                                    Else
                                       price = Val(warers.Fields("库存单价"))
                                    End If
                                 End If
                             Else
                                 price = nowprice
                                 
                             End If
                          Else
                              price = nowprice
                          End If
                          inrs.Fields("结存数量") = inrs.Fields("结存数量") - oldnumber + nownumber
                          inrs.Fields("结存金额") = Format(inrs.Fields("结存数量") * price, "#0.000000")
                       Else
                          cnnn.RollbackTrans
                          inrs.Close
                          outrs.Close
                          warers.Close
                          outrrss.Close
                          cnnn.Close
                          Screen.MousePointer = vbDefault
                          Exit Sub
                       End If
                    End If
                    
                    If Format(price) <> Trim(warers.Fields("库存单价")) Then
                       If Not (outrs.EOF And outrs.BOF) Then
                           outrs.MoveFirst
                           Dim sum1 As Double
                           sum1 = 0
                           Do Until outrs.EOF
                              sum1 = sum1 + Val(outrs.Fields("数量"))
                              outrs.Fields("库存单价") = Format(price, "#0.000000")
                              outrs.Fields("金额") = Format(price * outrs.Fields("数量"), "#0.000000")
                              outrs.Fields("结存数量") = storenumber + nownumber - oldnumber - sum1 + outnumber
                              outrs.Fields("结存金额") = Format(outrs.Fields("结存数量") * price, "#0.000000")
                              outrs.Update
                              outrs.MoveNext
                           Loop
                           'outrs.Update
                       End If
                      warers.Fields("库存单价") = Format(price, "#0.000000")
                    End If
                    warers.Fields("数量") = storenumber - oldnumber + nownumber
                    warers.Fields("金额") = Format(warers.Fields("库存单价") * warers.Fields("数量"), "#0.000000")
                    warers.Update
                 Else
                    If txtCompany.Text <> "" Then inrs.Fields("供货单位") = Trim(txtCompany.Text)
                    If txtMaked.Text <> "" Then inrs.Fields("制造厂家") = Trim(txtMaked.Text)
                    '& " " & Time
                    If Format(dtpDate.Value) <> Format(inrs.Fields("缴库日期")) Then inrs.Fields("缴库日期") = Format(Trim(dtpDate.Value), "General Date")
                    inrs.Fields("缴库人") = Trim(cobProvider.Text)
                    If cobDepartment.Text <> "" Then inrs.Fields("缴库部门") = Trim(cobDepartment.Text)
                    If txtBillcode.Text <> "" Then inrs.Fields("入库单编号") = Trim(txtBillcode.Text)
                    If txtInvoice.Text <> "" Then inrs.Fields("发票编号") = Trim(txtInvoice.Text)
                    If txtRemark.Text <> "" Then inrs.Fields("备注") = Trim(txtRemark.Text) & "修改过"
                 End If
                 
                
                inrs.Update
                cnnn.CommitTrans
                adoIn.Refresh
                MsgBox ("您已成功保存要修改的记录！")
             Else
                 cnnn.RollbackTrans
                 Screen.MousePointer = vbDefault
                 MsgBox "操作错误！不能修改！"
                 inrs.Close
                 warers.Close
                 outrs.Close
                 outrrss.Close
                 cnnn.Close
                 Exit Sub
              End If
           Else
              Screen.MousePointer = vbDefault
              MsgBox "找不到要修改的记录！不能修改！"
              inrs.Close
              warers.Close
              outrs.Close
              outrrss.Close
              cnnn.Close
              
              Exit Sub
           End If
           
           inrs.Close
           warers.Close
           outrs.Close
           outrrss.Close
           cnnn.Close
               
        Else
           Screen.MousePointer = vbDefault
           MsgBox ("物资编号和数量必需为数字！请重新输入物资编号或数量!")
           
           Exit Sub
        End If
     Else
        Screen.MousePointer = vbDefault
        MsgBox ("输入的信息太少！请输入物资编号、数量和缴库人!")
        
        Exit Sub
     End If
  End If
  */
    }
}
