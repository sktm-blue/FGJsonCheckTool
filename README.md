# FGJsonCheckTool
feed-generator�Ƀ��N�G�X�g�𑗂��ĕԂ��Ă���JSON���`�F�b�N����c�[���ł��B
![FGJsonCheckTool-v1 0 1-ss](https://github.com/sktm-blue/FGJsonCheckTool/assets/161000035/5fe04e98-ed4c-407f-a8b4-eceefaf260f7)

## �@�\
JSON�ŗ񋓂���Ă���URI��DB�ɖ₢���킹�A���e�̃e�L�X�g�Ȃǂ̏���\�����܂��B

## �O�����
2024/2/24���_�̌���feed-generator�ł͓��e�̖{�����̏ڍ׏���DB�Ɋi�[���Ă��܂���B
DB��text�J���������A�����ɖ{�����i�[����悤�������邱�ƂŖ{�c�[�����g�p�ł��܂��B
�쐬�҂�DB�ɍ��킹lang1,imageCount�Ƃ����J�������ǂݍ��݂܂����A�����͂Ȃ��Ă����삵�܂��B

## �g����
1. feed-generator�Ő������ꂽDB�t�@�C����Windows���ɏ������܂��B
2. ���̃c�[�����N�����A[�Q��...]�{�^����������DB�t�@�C����I�����܂��B
3. �ȉ��̏�����͂���[URI����]�{�^���������܂��B
   - [�v���g�R��]���Ɂuhttp�v���uhttps�v
   - [�z�X�g]���Ɂulocalhost:3000�v��feed-generator���ғ����Ă���z�X�g��
   - [DID]����feed-generator��.env�t�@�C���ɋL�q����FEEDGEN_PUBLISHER_DID
   - [shortname]����algos/*.ts�ɋL�q����shortname
4. URI����URI���\�����ꂽ��[�u���E�U���J��]�{�^���������܂��B
5. feed-generator������ɓ��삵�Ă����JSON���\������邽�߁A�����̃e�L�X�g�{�b�N�X�ɃR�s�y���܂��B
6. [��͂���]�{�^���������܂��B���e�̈ꗗ�������̃��X�g�r���[�ɕ\������܂��B
�܂����̌�[cursor��t����URI����]�{�^���������ƁA���̓��e�ꗗ���擾���邽�߂�URI����������܂��B

## feed-generator�Ƃ�
Bluesky���������J���Ă���t�B�[�h�W�F�l���[�^�[(�^�C�����C�������@)�ł��B  
https://github.com/bluesky-social/feed-generator  
  
feed-generator�̎g�p�@�ɂ��Ă͈ȉ��̃T�C�g���Q�l�ɂ����Ē����Ă��܂��B  
feed-generator��Bluesky�̃J�X�^���t�B�[�h����낤  
https://blog.estampie.work/archives/2972  
feed-generator��ǂ�  
https://scrapbox.io/Bluesky/feed-generator%E3%82%92%E8%AA%AD%E3%82%80

## �J����
- Visual Studio Community 2022
- .NET 8
- C#

## �g�p�p�b�P�[�W
- Microsoft.Data.Sqlite.Core
- SQLitePCLRaw.bundle_e_sqlite3

## �X�V����
- 1.0.1(2024/02/28) 
  - ��͌��ʂ����X�g�r���[�ŕ\������悤�ύX
  - URI�����@�\�ǉ�
  - URI���K��̃u���E�U�ŊJ���@�\�ǉ�
- 1.0.0(2024/02/24)
  - ����

## �쐬��
�����Ƃ�(Bluesky : https://bsky.app/profile/sktm.blue)
