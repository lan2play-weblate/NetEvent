﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using NetEvent.Client.Components;
using NetEvent.Client.Services;
using NetEvent.Shared.Dto;
using NetEvent.Shared.Dto.Administration;

namespace NetEvent.Client.Pages.Administration
{
    public partial class Users
    {
        [Inject]
        private IUserService _UserService { get; set; } = default!;

        [Inject]
        private IRoleService _RoleService { get; set; } = default!;

        [Inject]
        private ISnackbar _Snackbar { get; set; } = default!;

        [Inject]
        private IStringLocalizer<App> _Localizer { get; set; } = default!;

        private NetEventDataGrid<RoleDto>? RolesDataGrid;

        protected override async Task OnInitializedAsync()
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            AllUsers = await _UserService.GetUsersAsync(cancellationTokenSource.Token);
            await LoadRoles(cancellationTokenSource.Token);
        }

        private async Task LoadRoles(CancellationToken cancellationToken)
        {
            AllRoles = await _RoleService.GetRolesAsync(cancellationToken);
        }

        #region Users

        public List<AdminUserDto> AllUsers { get; private set; } = new List<AdminUserDto>();

        private string? _UsersSearchString;

        // quick filter - filter gobally across multiple columns with the same input
        private Func<AdminUserDto, bool> _usersQuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_UsersSearchString))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(x.UserName) && x.UserName.Contains(_UsersSearchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(x.FirstName) && x.FirstName.Contains(_UsersSearchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(x.LastName) && x.LastName.Contains(_UsersSearchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (!string.IsNullOrEmpty(x.Email) && x.Email.Contains(_UsersSearchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        };

        private async Task CommittedUserChangesAsync(AdminUserDto updatedUser)
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            var result = await _UserService.UpdateUserAsync(updatedUser, cancellationTokenSource.Token).ConfigureAwait(false);

            if (result.Successful)
            {
                result = await _UserService.UpdateUserRoleAsync(updatedUser.Id, updatedUser.Role.Id, cancellationTokenSource.Token).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(result.MessageKey) && !string.IsNullOrEmpty(updatedUser.Email))
            {
                _Snackbar.Add(_Localizer.GetString(result.MessageKey, updatedUser.Email), result.Successful ? Severity.Success : Severity.Error);
            }
        }
        #endregion

        #region Roles

        public List<RoleDto> AllRoles { get; private set; } = new List<RoleDto>();

        public RoleDto? SelectedRole { get; private set; }

        private string? _RoleSearchString;

        private string? SelectionLabelValue { get; set; }

        // quick filter - filter gobally across multiple columns with the same input
        private Func<RoleDto, bool> _roleQuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_RoleSearchString))
            {
                return true;
            }

            if (x.Name.Contains(_RoleSearchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        };

        private async Task CommittedRoleChangesAsync(RoleDto updatedRole)
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            ServiceResult result;
            if (string.IsNullOrEmpty(updatedRole.Id))
            {
                result = await _RoleService.AddRoleAsync(updatedRole, cancellationTokenSource.Token).ConfigureAwait(false);
            }
            else
            {
                result = await _RoleService.UpdateRoleAsync(updatedRole, cancellationTokenSource.Token).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(result.MessageKey))
            {
                _Snackbar.Add(_Localizer.GetString(result.MessageKey, updatedRole.Name), result.Successful ? Severity.Success : Severity.Error);
            }

            await LoadRoles(cancellationTokenSource.Token);
        }

        private async Task DeletedItemChanges(EventCallbackArgs<RoleDto> deletedRoleArgs)
        {
            using var cancellationTokenSource = new CancellationTokenSource();
            var result = await _RoleService.DeleteRoleAsync(deletedRoleArgs.Value, cancellationTokenSource.Token).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(result.MessageKey))
            {
                _Snackbar.Add(_Localizer.GetString(result.MessageKey, deletedRoleArgs.Value.Name), result.Successful ? Severity.Success : Severity.Error);
            }

            if (!result.Successful)
            {
                deletedRoleArgs.Cancel = true;
            }
        }

        private string CreateSelectionLabel(List<string> selectedValues)
        {
            return selectedValues.Count switch
            {
                int n when n == 1 => $"{selectedValues.Count} {_Localizer["Administration.Users.Roles.SelectPermissionSingular"]}",
                int n when n > 1 => $"{selectedValues.Count} {_Localizer["Administration.Users.Roles.SelectPermissionPlural"]}",
                _ => (string)_Localizer["Administration.Users.Roles.NothingSelected"],
            };
        }
        #endregion
    }
}
