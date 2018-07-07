
// FileLoader.removeGabageFiles
// 更新程序会删除多余的文件，删除代码以阻止删除
// int count2 = list.Count;
// for (int k = 0; k < count2; k++)
// {
// 	File.Delete(list[k]);
// }

// 同上，但似乎非必要
// LocalPathchMgr.installPatchFileVer
// string updatePatchFilePath = this.getUpdatePatchFilePath(@string);
// if (File.Exists(updatePatchFilePath))
// {
// 	File.Delete(updatePatchFilePath);
// }

// PatchSystem.onRecv_PatchList
// 保证_patch文件夹存在
Directory.CreateDirectory(FileLoader.INSTALL_DIR + "/_patch");
// 保存原版catalog.dat，非必要
File.WriteAllBytes(FileLoader.INSTALL_DIR + "/_patch/__catalog.dat", array);
// 存在catalog.patch则读取并合并
if(File.Exists(FileLoader.INSTALL_DIR + "/_patch/catalog.patch"))
{
	byte[] array2 = File.ReadAllBytes(FileLoader.INSTALL_DIR + "/_patch/catalog.patch");
	Array.Resize<byte>(ref array, array.Length + array2.Length);
	array2.CopyTo(array, array.Length - array2.Length);
}

// 下载cpk_file.csv的地方
// CPKMgr.onCsvDownloadEndCB
// 存在cpk_file.patch则读取并合并
stringData += (File.Exists(FileLoader.INSTALL_DIR + "/_patch/cpk_file.patch") ? File.ReadAllText(FileLoader.INSTALL_DIR + "/_patch/cpk_file.patch") : "");
// 保持原版cpk_file.csv
this.writeCsv(request.GetStringData());

// 下载cpk_patch.txt的地方
// CPKMgr.onPatchTextDownloadEndCB
// 存在cpk_patch.patch则读取并合并
stringData += (File.Exists(FileLoader.INSTALL_DIR + "/_patch/cpk_patch.patch") ? File.ReadAllText(FileLoader.INSTALL_DIR + "/_patch/cpk_patch.patch") : "");
// 保持新旧的cpk列表一致，并保持原版cpk_patch.txt
if (!string.IsNullOrEmpty(stringData))
{
	this.m_new_version_info_list = this.createVersionInfoList(stringData);
	this.m_local_version_info_list = this.createVersionInfoList(stringData);
	this.writeVersionInfo(this.createVersionInfoList(request.GetStringData()));
}

// 插入补丁
// CPKMgr.loadCsv

// string data = streamReader.ReadToEnd();
data += (File.Exists(FileLoader.INSTALL_DIR + "/_patch/cpk_file.patch") ? File.ReadAllText(FileLoader.INSTALL_DIR + "/_patch/cpk_file.patch") : "");

// 同上，插入补丁
// CPKMgr.loadLocalVersionInfoList
// string patch_str = streamReader.ReadToEnd();
patch_str += (File.Exists(FileLoader.INSTALL_DIR + "/_patch/cpk_patch.patch") ? File.ReadAllText(FileLoader.INSTALL_DIR + "/_patch/cpk_patch.patch") : "");

// 阻止删除CPK文件
// CPKMgr.deleteCPKFile1
// File.Delete(this.getInstallCpkPath(cpk_name));

// 插入补丁
// 这里由于无法编译，通过拷贝上面相同逻辑的IL指令实现
//SoundMgr.OnLoadCpkData
text += (File.Exists(FileLoader.INSTALL_DIR + "/_patch/cpk_file.patch") ? File.ReadAllText(FileLoader.INSTALL_DIR + "/_patch/cpk_file.patch") : "");
// 插入补丁
// 这里由于无法编译，通过拷贝上面相同逻辑的IL指令实现
// SoundMgr.OnLoadCPKPatch
stringData += (System.IO.File.Exists(FileLoader.INSTALL_DIR + "/_patch/cpk_patch.patch") ? System.IO.File.ReadAllText(FileLoader.INSTALL_DIR + "/_patch/cpk_patch.patch") : "");


// -------------------------------------------保留
// 保存错误
// Log
	System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "ErrLog.txt", message.ToString() + "\r\n");

// 每次强化都显示满名声祝贺
// AutoFusionRsultExecutor.onCloseFusionReusltWindow
	if (flag && flag2)
	{
		play_type = CardFusionResult.PlayType.ALL;
	}
	else if (flag)
	{
		play_type = CardFusionResult.PlayType.ALL;
	}
	else if (flag2)
	{
		play_type = CardFusionResult.PlayType.ALL;
	}

// 每次强化都显示满名声祝贺
// ExpFusionResultUIController
	// if (!ArrayUtility.isNullOrEmpty(this.m_receive_data.result_card.fame_up) && this.m_receive_data.result_card.fame_up[0].new_fame >= Const.CARD_FAME_MAX)
	// {
		this.m_fusion_result_window.startEffect(CardFusionResult.PlayType.ALL, this.m_receive_data.result_card, this.m_receive_data.back_uniqids != null || this.m_receive_data.back_container_uniqids != null || this.m_receive_data.back_stack_cards != null, new Action<CardFusionResult.StateType>(this.onStateEnd), delegate
		{
			this.<is_end_effect>__0 = true;
		});
	// }
	// else
	// {
	// 	this.openFameUpWindow();
	// 	this.m_fusion_result_window.startEffect(CardFusionResult.PlayType.FUSION, this.m_receive_data.result_card, this.m_receive_data.back_uniqids != null || this.m_receive_data.back_container_uniqids != null || this.m_receive_data.back_stack_cards != null, null, delegate
	// 	{
	// 		this.<is_end_effect>__0 = true;
	// 	});
	// }

// 保存登录信息
// LoginMgr.onLogin(SDK)
	System.IO.File.WriteAllText(FileLoader.INSTALL_DIR+"login.txt", jsonstr);

// 检查掉落中是否存在EX，是则创建DropEx.csv文件，否则删除
// ProtoGen.TeamBattleSoloStartReceive
	System.IO.File.Delete(FileLoader.INSTALL_DIR + "DropEx.csv");
	System.IO.File.Delete(FileLoader.INSTALL_DIR + "Drop.txt");

	if (teamBattleSoloStartReceiveData.battles[num3].drop[num4].drops[num5].reward_typeid == 7)
	{
		System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "DropEx.csv", DateTime.Now.ToString("f") + "\r\n");
	}
	System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "Drop.txt", teamBattleSoloStartReceiveData.battles[num3].drop[num4].drops[num5].type + ",");
	System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "Drop.txt", teamBattleSoloStartReceiveData.battles[num3].drop[num4].drops[num5].reward_typeid + ",");
	System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "Drop.txt", teamBattleSoloStartReceiveData.battles[num3].drop[num4].drops[num5].num + ",");
	System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "Drop.txt", teamBattleSoloStartReceiveData.battles[num3].drop[num4].drops[num5].card_lv + ",");
	System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "Drop.txt", teamBattleSoloStartReceiveData.battles[num3].drop[num4].drops[num5].card_fame + ",");
	System.IO.File.AppendAllText(FileLoader.INSTALL_DIR + "Drop.txt", teamBattleSoloStartReceiveData.battles[num3].drop[num4].drops[num5].card_love + "\r\n");

// 删除出卡动画
// SkillDataContainer.onRoleCsvParserWithId

// 显示血量
// EnemyName
// 增加类变量ename
public string ename = string.Empty;
// 增加函数SetHP
public void SetHP(long hp)
{
	string str = "";

	if(hp>100000000L) {
		str += hp / 100000000L + "亿";
		hp -= hp / 100000000L * 100000000L;
	}
	if(hp>10000L) {
		str += hp / 10000L + "万";
		hp -= hp / 10000L * 10000L;
	}
	if(hp>0) {
		str += hp;
	}
	if(hp<=0) {
		str = "击破";
	}

	this.nameLabel.text = this.ename + "<"+str+">";

	this.buffObj.transform.localPosition = new Vector3(this.basePosX + this.nameLabel.GetDiffWidth() / 2f, this.buffObj.transform.localPosition.y, this.buffObj.transform.localPosition.z);
}
// EnemyName.SetName
// 设置名称时保存血量
this.ename = name;
// EnemyHPSet._updateHpBar
// 调用SetHP
this.enemyName.SetHP(hp);


