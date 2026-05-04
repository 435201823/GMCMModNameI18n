# GMCM Mod Name I18n

为 [Generic Mod Config Menu (GMCM)](https://www.nexusmods.com/stardewvalley/mods/5098) 中的模组名称提供国际化（i18n）支持的 [SMAPI](https://smapi.io) 模组。

## 原理

GMCM 展示模组名称时直接使用其 manifest 中的 `Name` 字段，通常为英文。本模组通过 Harmony 修补 GMCM 的 `ModConfig.ModName` getter，利用 SMAPI 翻译 API 查找键值为 `gmcmodnamei18n.<UniqueModID>` 的翻译文本。

当存在对应翻译时，GMCM 菜单中显示的模组名称会被替换为翻译后的字符串；未找到翻译时保留原名。

## 安装

1. 安装 [SMAPI](https://smapi.io)（4.0.0 或更高版本）。
2. 安装 [Generic Mod Config Menu](https://www.nexusmods.com/stardewvalley/mods/5098)。
3. 下载本模组并解压到 `Mods` 文件夹。

## 添加翻译

编辑 `i18n/default.json` 文件（或创建语言特定文件，如 `i18n/zh.json`）。每条条目将模组的 UniqueID 映射到翻译后的名称：

```json
{
  "gmcmodnamei18n.<ModUniqueID>": "翻译后的名称"
}
```

示例（`i18n/zh.json`）：

```json
{
  "gmcmodnamei18n.spacechase0.GenericModConfigMenu": "通用模组配置菜单",
  "gmcmodnamei18n.Pathoschild.FastAnimations": "快速动画"
}
```

每个模组的 UniqueID 可以在其 `manifest.json` 文件中找到。

## 兼容性

- 需要 SMAPI 4.0.0+
- 需要 Generic Mod Config Menu
- 兼容 Stardew Valley 1.6+
- 适用于所有兼容 GMCM 的模组

## 许可

本项目为开源项目，可自由使用、修改和分发。
